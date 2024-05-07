using Godot;

public partial class WordStats : Resource
{
    [ExportCategory("Score")]
    [Export]
    public int Points { get; set; } = 5;

    [Export]
    public int ComboIncrease { get; set; } = 1;

    [ExportCategory("Display")]
    [Export]
    public string Color { get; set; } = "white";

    /// <summary>
    /// Note that his overrides the Color property. TODO allow "rainbow" to be a value for color and render accordingly.
    /// </summary>
    [Export] public bool RainbowEnabled { get; set; } = false;

    // Make sure you provide a parameterless constructor.
    // In C#, a parameterless constructor is different from a
    // constructor with all default values.
    // Without a parameterless constructor, Godot will have problems
    // creating and editing your resource via the inspector.
    public WordStats() : this(5, 1) { }

    public WordStats(int points, int comboIncrease)
    {
        Points = points;
        ComboIncrease = comboIncrease;
    }
}