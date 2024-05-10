using Godot;

public interface IScore
{
    public int Points { get; }
    public int WordsCleared { get; }
    public int ComboMultiplier { get; }
    public int MaxComboMultiplier { get; }
}

/// <summary>
/// Why is this a class and not a struct or interface? Answer: Godot Signals can neither use structs nor interfaces. It must be something that extends GodotObject.
/// </summary>
public partial class ScoreDto : GodotObject
{
    public ScoreDto(IScore score)
    {
        Points = score.Points;
        WordsCleared = score.WordsCleared;
        ComboMultiplier = score.ComboMultiplier;
        MaxComboMultiplier = score.MaxComboMultiplier;
    }

    public int Points { get; }
    public int WordsCleared { get; }
    public int ComboMultiplier { get; }
    public int MaxComboMultiplier { get; }
}