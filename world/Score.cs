using System;

class Score : IScore
{
    private int _comboMultiplier = 0;
    private int _points = 0;
    private int _wordsCleared = 0;
    private int _maxComboMultiplier = 0;


    public int Points { get => _points; }
    public int WordsCleared { get => _wordsCleared; }
    public int ComboMultiplier
    {
        get => _comboMultiplier; set
        {
            _comboMultiplier = value;
            _maxComboMultiplier = Math.Max(_comboMultiplier, _maxComboMultiplier);
        }
    }

    public int MaxComboMultiplier { get => _maxComboMultiplier; }

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