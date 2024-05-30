using System;
using Dtos;

namespace World
{
    sealed class Score : IScore
    {
        private int _comboMultiplier;
        private int _points;
        private int _wordsCleared;
        private int _maxComboMultiplier;

        public int Points
        {
            get => _points;
        }
        public int WordsCleared
        {
            get => _wordsCleared;
        }
        public int ComboMultiplier
        {
            get => _comboMultiplier;
            set
            {
                _comboMultiplier = value;
                _maxComboMultiplier = Math.Max(_comboMultiplier, _maxComboMultiplier);
            }
        }

        public int MaxComboMultiplier
        {
            get => _maxComboMultiplier;
        }

        public float MaxTime { get; private set; }

        public int PointsIncrease { get; private set; }

        public int ComboMultiplierIncrease { get; private set; }

        public float TimeIncrease { get; private set; }

        internal void CompleteWord(WordStats wordStats)
        {
            ComboMultiplierIncrease = wordStats.ComboIncrease;

            ComboMultiplier += wordStats.ComboIncrease;
            var pointsIncrease = wordStats.Points * _comboMultiplier; // must come after setting comboMultiplier
            _points += pointsIncrease;
            _wordsCleared++;

            PointsIncrease = pointsIncrease;
            TimeIncrease = wordStats.AddedTime;
            MaxTime += wordStats.AddedTime;
        }

        internal void ResetCombo()
        {
            _comboMultiplier = 0;
        }
    }
}
