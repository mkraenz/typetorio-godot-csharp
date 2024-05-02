using Godot;

public partial class Eventbus : Node
{
    [Signal]
    public delegate void WordClearedEventHandler(string word);


    public void EmitWordCleared(string word)
    {
        EmitSignal(SignalName.WordCleared, word);
    }
}