using System;
using System.Collections.Generic;
using Dtos;
using Godot;
using Dict = Godot.Collections.Dictionary<string, Godot.Variant>;

namespace Globals
{
    public enum Unlocks
    {
        Shop,
        ClassicFocusMode,
        BlueWord,
        RainbowWord,
        NoDefaultWords,
    }

    // what to unlock (i.e. the key), boolean or multiple unlocks in one, price
    public partial class GameProgress : Node
    {
        [Signal]
        public delegate void PointsToSpendChangedEventHandler(int newPoints);

        private int _pointsToSpend;
        private Dict _unlocks = new Dict() { };
        public int TotalPoints { get; set; }
        public int PointsToSpend
        {
            get => _pointsToSpend;
            set
            {
                _pointsToSpend = value;
                EmitSignal(SignalName.PointsToSpendChanged, _pointsToSpend);
            }
        }

        private Eventbus _eventbus;

        Dict Unlocks
        {
            get => _unlocks;
            set
            {
                _unlocks = value;
                _eventbus.EmitUnlocksChanged(_unlocks);
            }
        }
        private static string _filepath = "user://game.cfg";

        public override void _Ready()
        {
            _eventbus = GDAccessors.GetEventbus(this);
            _eventbus.GameEnded += OnGameEnded;
            Load();
        }

        private void OnGameEnded(ScoreDto score)
        {
            AddPoints(score.Points);
            Save();
        }

        public void UnlockFeature(Unlocks feature)
        {
            string featureName = Enum.GetName(typeof(Unlocks), feature);
            Unlocks.Add(featureName, true);
            Save();
            _eventbus.EmitUnlocksChanged(_unlocks);
        }

        public bool CanAfford(int price) => PointsToSpend >= price;

        public void Buy(Unlocks feature, int price)
        {
            if (!CanAfford(price))
                throw new ArgumentException("Price too high. Cant afford.");
            PointsToSpend -= price;
            UnlockFeature(feature);
        }

        public bool HasUnlocked(Unlocks feature)
        {
            string featureName = Enum.GetName(typeof(Unlocks), feature);
            return (bool)this.Unlocks.GetValueOrDefault(featureName);
        }

        public void Save()
        {
            var config = new ConfigFile();

            config.SetValue("Progress", "TotalPoints", TotalPoints);
            config.SetValue("Progress", "PointsToSpend", PointsToSpend);
            foreach (var (key, value) in Unlocks)
            {
                config.SetValue("Unlocks", key, value);
            }

            var err = config.Save(_filepath);
            if (err != Error.Ok)
            {
                // FIXME: sth went wrong. notify caller and eventually player?
            }
        }

        public void Load()
        {
            var config = new ConfigFile();
            Error err = config.Load(_filepath);
            if (err != Error.Ok)
                return; // ignore if nonexistent or corrupted

            foreach (string section in config.GetSections())
            {
                switch (section)
                {
                    case "Progress":
                        {
                            TotalPoints = (int)config.GetValue(section, "TotalPoints");
                            PointsToSpend = (int)config.GetValue(section, "PointsToSpend");
                            break;
                        }
                    case "Unlocks":
                        {
                            var keys = config.GetSectionKeys("Unlocks");
                            foreach (string key in keys)
                            {
                                Unlocks[key] = config.GetValue(section, key);
                            }
                            break;
                        }
                }
            }
        }

        private void AddPoints(int points)
        {
            TotalPoints += points;
            PointsToSpend = Math.Min(PointsToSpend + points, 999999);
        }
    }
}
