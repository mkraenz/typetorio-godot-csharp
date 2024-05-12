using System;
using Globals;
using Godot;

namespace UI
{
    public partial class PointsToSpend : MarginContainer
    {
        private GameProgress _gameProgress;
        private MyScore _score;

        public override void _Ready()
        {
            _gameProgress = GDAccessors.GetGameProgress(this);
            _score = GetNode<MyScore>("MyScore");

            _gameProgress.PointsToSpendChanged += OnPointsToSpendChanged;

            _score.Value = _gameProgress.PointsToSpend.ToString("D6");
        }

        private void OnPointsToSpendChanged(int newPoints)
        {
            _score.Value = newPoints.ToString("D6");
        }
    }
}
