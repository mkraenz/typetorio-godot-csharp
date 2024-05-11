using Godot;

namespace World
{
    [GlobalClass]
    public partial class WordDistribution : Resource
    {
        [Export]
        public int Default { get; set; } = 1;

        [Export]
        public int Blue { get; set; } = 0;

        [Export]
        public int Rainbow { get; set; } = 0;

        private WordStats _defaultWordStats = ResourceLoader.Load<WordStats>(
            "res://world/word/wordstats/DefaultWordStats.tres"
        );
        private WordStats _blueWordStats = ResourceLoader.Load<WordStats>(
            "res://world/word/wordstats/SkyblueWordStats.tres"
        );
        private WordStats _rainbowWordStats = ResourceLoader.Load<WordStats>(
            "res://world/word/wordstats/RainbowWordStats.tres"
        );

        private RandomNumberGenerator _rng;

        public WordDistribution()
        {
            _rng = new RandomNumberGenerator();
        }

        public WordStats GetRandomType()
        {
            var sum = Default + Blue + Rainbow;
            var winner = _rng.RandiRange(0, sum - 1);
            if (winner < Default)
                return _defaultWordStats;
            if (winner < Default + Blue)
                return _blueWordStats;
            if (winner < Default + Blue + Rainbow)
                return _rainbowWordStats;
            return _defaultWordStats;
        }
    }
}
