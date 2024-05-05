using Godot;

public partial class GameEnded : GodotObject
{
    public GameEnded(int points, int words, float comboMultiplier)
    {
        Points = points;
        ComboMultiplier = comboMultiplier;
        Words = words;
    }

    public float ComboMultiplier { get; }
    public int Points { get; }
    public int Words { get; }
}