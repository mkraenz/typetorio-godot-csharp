using Godot;

public partial class WordStats : Resource
{
    [Export]
    public int Points { get; set; }

    [Export]
    public int ComboIncrease { get; set; }

    // Make sure you provide a parameterless constructor.
    // In C#, a parameterless constructor is different from a
    // constructor with all default values.
    // Without a parameterless constructor, Godot will have problems
    // creating and editing your resource via the inspector.
    public WordStats() : this(5, 1) { }

    public WordStats(int points = 5, int comboIncrease = 1)
    {
        Points = points;
        ComboIncrease = comboIncrease;
    }
}