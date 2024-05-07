using Godot;

public enum SpecialEffect
{
    None,
    Rainbow
}

public partial class WordStats : Resource
{
    [ExportCategory("Score")]
    [Export]
    public int Points { get; set; } = 5;

    [Export]
    public int ComboIncrease { get; set; } = 1;

    [ExportCategory("Display")]
    [Export(PropertyHint.ColorNoAlpha)]
    public Color Color { get; set; } = Colors.White;

    [Export(PropertyHint.Range, "0,10")]
    public float FontScale { get; set; } = 1;


    /// <summary>
    /// Note that his overrides the Color property and possibly others.
    /// </summary>
    [Export(PropertyHint.Enum)] public SpecialEffect SpecialEffects { get; set; } = SpecialEffect.None;

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