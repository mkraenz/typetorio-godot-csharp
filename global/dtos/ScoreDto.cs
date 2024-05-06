using Godot;

/// <summary>
/// Why is this a class and not a struct or interface? Answer: Godot Signals can neither use structs nor interfaces. It must be something that extends GodotObject.
/// </summary>
public partial class ScoreDto : GodotObject
{
    // TODO use an interface (or google for how to shorten c# long parameter list)
    public ScoreDto(int points, int wordsCleared, int comboMultiplier, int maxComboMultiplier)
    {
        Points = points;
        WordsCleared = wordsCleared;
        ComboMultiplier = comboMultiplier;
        MaxComboMultiplier = maxComboMultiplier;
    }

    public int Points { get; }
    public int WordsCleared { get; }
    public int ComboMultiplier { get; }
    public int MaxComboMultiplier { get; }
}