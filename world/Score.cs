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

        internal void CompleteWord(WordStats wordStats)
        {
            ComboMultiplier += wordStats.ComboIncrease;
            _points += wordStats.Points * _comboMultiplier;
            _wordsCleared++;
        }

        internal void ResetCombo()
        {
            _comboMultiplier = 0;
        }
    }
}
