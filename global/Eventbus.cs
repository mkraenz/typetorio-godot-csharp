using System;
using Godot;

public partial class Eventbus : Node
{
    [Signal]
    public delegate void WordClearedEventHandler(string word, float comboMultiplier);

    [Signal]
    public delegate void ComboChangedEventHandler(float comboMultiplier);

    public void EmitWordCleared(string word, float comboMultiplier)
    {
        EmitSignal(SignalName.WordCleared, word, comboMultiplier);
    }

    public void emitComboChanged(float comboMultiplier)
    {
        EmitSignal(SignalName.ComboChanged, comboMultiplier);
    }
}