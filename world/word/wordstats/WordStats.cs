using Godot;

namespace World
{
    public enum SpecialEffect
    {
        None,
        Rainbow
    }

    [GlobalClass]
    public partial class WordStats : Resource
    {
        [ExportCategory("Score")]
        [Export]
        public int Points { get; set; } = 5;

        [Export]
        public int ComboIncrease { get; set; } = 1;


        /// <summary>
        /// NOTE: BaseSpawnRate may still become zero if a word is not unlocked yet.
        /// </summary>
        [ExportCategory("Spawn Rate")]
        [Export]
        public int BaseSpawnRate { get; set; } = 0;

        [ExportCategory("Display")]
        [Export(PropertyHint.ColorNoAlpha)]
        public Color Color { get; set; } = Colors.White;

        [Export(PropertyHint.Range, "0,10")]
        public float FontScale { get; set; } = 1;

        /// <summary>
        /// Note that his overrides the Color property and possibly others.
        /// </summary>
        [Export(PropertyHint.Enum)]
        public SpecialEffect SpecialEffects { get; set; } = SpecialEffect.None;

        // Make sure you provide a parameterless constructor.
        // In C#, a parameterless constructor is different from a
        // constructor with all default values.
        // Without a parameterless constructor, Godot will have problems
        // creating and editing your resource via the inspector.
        public WordStats()
            : this(5, 1) { }

        public WordStats(int points, int comboIncrease)
        {
            Points = points;
            ComboIncrease = comboIncrease;
        }
    }
}
