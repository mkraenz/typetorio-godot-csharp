using System;
using Godot;

public partial class Eventbus : Node
{

    [Signal] public delegate void WordClearedEventHandler(string word, ScoreDto score);
    [Signal] public delegate void ComboChangedEventHandler(int comboMultiplier);
    [Signal] public delegate void StartClassicGameClickedEventHandler();
    [Signal] public delegate void StartClassicSingleWordGameClickedEventHandler();
    [Signal] public delegate void GameEndedEventHandler(ScoreDto score);
    [Signal] public delegate void BackToTitleClickedEventHandler();
    [Signal] public delegate void GameStartedEventHandler(string gameType, int gameTimeInSec);

    public void EmitWordCleared(string word, ScoreDto score)
    {
        EmitSignal(SignalName.WordCleared, word, score);
    }

    public void EmitComboChanged(int comboMultiplier)
    {
        EmitSignal(SignalName.ComboChanged, comboMultiplier);
    }

    public void EmitStartClassicGameClicked()
    {
        EmitSignal(SignalName.StartClassicGameClicked);
    }

    public void EmitStartClassicSingleWordGameClicked()
    {
        EmitSignal(SignalName.StartClassicSingleWordGameClicked);
    }

    public void EmitGameEnded(ScoreDto score)
    {
        EmitSignal(SignalName.GameEnded, score);
    }

    public void EmitBackToTitleClicked()
    {
        EmitSignal(SignalName.BackToTitleClicked);
    }

    internal void EmitGameStarted(string gameType, int gameTimeInSec)
    {
        EmitSignal(SignalName.GameStarted, gameType, gameTimeInSec);
    }
}