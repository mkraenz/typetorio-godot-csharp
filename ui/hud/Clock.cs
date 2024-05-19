using System;
using Dtos;
using Globals;
using Godot;

namespace UI
{
    public partial class Clock : Label
    {
        private double _timeLeftInSecs;

        /// <summary>
        /// Only used for component dev when running this scene from the editor.
        /// </summary>
        [Export]
        public double TimeLeftInSecs
        {
            get => _timeLeftInSecs;
            set
            {
                _timeLeftInSecs = Math.Max(value, 0.0);
                UpdateText();
            }
        }


        private Eventbus _eventbus;

        public override void _Ready()
        {
            SetProcess(false);
            _eventbus = GDAccessors.GetEventbus(this);

            _eventbus.GameStarted += OnGameStarted;
            _eventbus.GameEnded += OnGameEnded;
            _eventbus.GameTimeChanged += OnGameTimeChanged;
            UpdateText();
        }

        private void OnGameTimeChanged(float timeLeftInSec)
        {
            TimeLeftInSecs = timeLeftInSec;
        }

        private void OnGameEnded(object _)
        {
            SetProcess(false);
        }

        private void UpdateText()
        {
            int min = (int)(_timeLeftInSecs / 60.0);
            int sec = (int)(_timeLeftInSecs % 60.0);

            int ms = (int)((_timeLeftInSecs * 1000.0) % 1000.0);
            Text = $"{min.ToString("D2")}:{sec.ToString("D2")}:{ms.ToString("D3")}";
        }

        private void OnGameStarted(string gameType, int gameTimeInSec)
        {
            SetProcess(true);
            TimeLeftInSecs = gameTimeInSec;
        }

        public override void _Process(double delta)
        {
            base._Process(delta);
            TimeLeftInSecs -= delta;
        }
    }
}
