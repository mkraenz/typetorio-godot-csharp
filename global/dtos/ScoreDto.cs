using Godot;

namespace Dtos
{
    public interface IScore
    {
        // Totals
        public int Points { get; }
        public int WordsCleared { get; }
        public int ComboMultiplier { get; }
        public int MaxComboMultiplier { get; }
        public float MaxTime { get; }

        /// How much it increased by the last word.
        public int PointsIncrease { get; }
        public int ComboMultiplierIncrease { get; }
        public float TimeIncrease { get; }
    }

    /// <summary>
    /// Why is this a class and not a struct or interface? Answer: Godot Signals can neither use structs nor interfaces. It must be something that extends GodotObject.
    /// </summary>
    public partial class ScoreDto : GodotObject, IScore
    {
        public ScoreDto(IScore score)
        {
            Points = score.Points;
            WordsCleared = score.WordsCleared;
            ComboMultiplier = score.ComboMultiplier;
            MaxComboMultiplier = score.MaxComboMultiplier;
            MaxTime = score.MaxTime;
            PointsIncrease = score.PointsIncrease;
            ComboMultiplierIncrease = score.ComboMultiplierIncrease;
            TimeIncrease = score.TimeIncrease;
        }

        public int Points { get; }
        public int WordsCleared { get; }
        public int ComboMultiplier { get; }
        public int MaxComboMultiplier { get; }
        public float MaxTime { get; }

        public int PointsIncrease { get; }
        public int ComboMultiplierIncrease { get; }
        public float TimeIncrease { get; }
    }
}
