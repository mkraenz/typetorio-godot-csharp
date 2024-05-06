using System;

class Score
{
    private int _comboMultiplier = 0;
    private int _points = 0;
    private int _wordsCleared = 0;
    private int _maxComboMultiplier = 0;


    public int Points { get => _points; }
    public int WordsCleared { get => _wordsCleared; }
    public int ComboMultiplier { get => _comboMultiplier; }
    public int MaxComboMultiplier { get => _maxComboMultiplier; }

    internal void CompleteWord(int pointsValue, int comboValue)
    {
        _comboMultiplier += comboValue;
        _points += pointsValue * _comboMultiplier;
        _wordsCleared++;
    }

    internal void ResetCombo()
    {
        _comboMultiplier = 0;
    }
}