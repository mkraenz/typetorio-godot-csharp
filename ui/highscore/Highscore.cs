using System;
using Dtos;
using Globals;
using Godot;

namespace UI
{
    public interface IHighscoreLabels
    {
        string Value { set; }
    }

    public partial class Highscore : MarginContainer
    {
        private Eventbus _eventbus;
        private IHighscoreLabels _labels;

        public override void _Ready()
        {
            _eventbus = GDAccessors.GetEventbus(this);
            _labels = GetNode<IHighscoreLabels>("MyScore");

            _eventbus.WordCleared += OnWordCleared;
            _eventbus.GameAboutToStart += Reset;
        }

        private void Reset()
        {
            _labels.Value = 0.ToString("D6");
        }

        private void OnWordCleared(string _word, ScoreDto score)
        {
            _labels.Value = score.Points.ToString("D6");
        }
    }
}
