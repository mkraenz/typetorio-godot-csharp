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
    }

    // what to unlock (i.e. the key), boolean or multiple unlocks in one, price
    public partial class GameProgress : Node
    {

        private Dict _unlocks = new Dict() { };
        public int TotalPoints { get; set; }
        public int PointsToSpend { get; set; }

        private Eventbus _eventbus;



        Dict Unlocks
        {
            get => _unlocks;
            set
            {
                _unlocks = value;
            }
        }
        private static string _filepath = "user://game.cfg";

        public override void _Ready()
        {
            _eventbus = GDAccessors.GetEventbus(this);
            _eventbus.GameEnded += OnGameEnded;
        }

        private void OnGameEnded(ScoreDto score)
        {
            var gameProgress = GDAccessors.GetGameProgress(this);
            gameProgress.AddPoints(score.Points);
            gameProgress.Save();
        }

        public void UnlockStuff(Unlocks feature)
        {
            string featureName = System.Enum.GetName(typeof(Unlocks), feature);
            Unlocks.Add(featureName, true);
        }

        public bool HasUnlocked(Unlocks feature)
        {
            string featureName = System.Enum.GetName(typeof(Unlocks), feature);
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
            if (err != Error.Ok) return; // ignore if nonexistent or corrupted

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


        internal void AddPoints(int points)
        {
            TotalPoints += points;
            PointsToSpend += points;
        }
    }

}