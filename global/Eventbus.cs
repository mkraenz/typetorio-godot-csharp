using System;
using Godot;

public partial class Eventbus : Node
{

    [Signal] public delegate void WordClearedEventHandler(string word, float comboMultiplier);
    [Signal] public delegate void ComboChangedEventHandler(float comboMultiplier);
    [Signal] public delegate void StartClassicGameClickedEventHandler();
    [Signal] public delegate void GameEndedEventHandler(GameEnded daata);
    [Signal] public delegate void BackToTitleClickedEventHandler();
    [Signal] public delegate void GameStartedEventHandler(string gameType, int gameTimeInSec);

    public void EmitWordCleared(string word, float comboMultiplier)
    {
        EmitSignal(SignalName.WordCleared, word, comboMultiplier);
    }

    public void EmitComboChanged(float comboMultiplier)
    {
        EmitSignal(SignalName.ComboChanged, comboMultiplier);
    }

    public void EmitStartClassicGameClicked()
    {
        EmitSignal(SignalName.StartClassicGameClicked);
    }

    public void EmitGameEnded(GameEnded data)
    {
        EmitSignal(SignalName.GameEnded, data);
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