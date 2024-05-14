using System;
using System.Collections.Generic;
using System.Linq;
using Exceptions;
using Godot;

namespace World
{
    public readonly struct Spawn
    {
        public Spawn(WordStats word, int spawnRate)
        {
            Word = word;
            SpawnRate = spawnRate;
        }

        public WordStats Word { get; }
        public int SpawnRate { get; }
    }

    public partial class WordSpawner : Control
    {
        public GameSettings GameSettings { get; set; }

        public Spawn[] WordPool { get; set; }
        private Dictionary<string, Word> _currentWords = new Dictionary<string, Word> { };

        private Timer _timer;

        private PackedScene _WordScene = ResourceLoader.Load<PackedScene>(
            "res://world/word/Word.tscn"
        );
        private RandomNumberGenerator _rng = new RandomNumberGenerator();

        public override void _Ready()
        {
            _timer = GetNode<Timer>("Timer");
        }

        private string GetRandomWord()
        {
            string next = Assets.WordData.GetRandomWord();
            if (_currentWords.ContainsKey(next))
            {
                return GetRandomWord();
            }
            return next;
        }

        public void Spawn()
        {
            if (_currentWords.Count >= GameSettings.MaxConcurrentWords)
                return;
            string nextWord = GetRandomWord();
            var word = _WordScene.Instantiate() as Word;
            word.Text = nextWord;
            word.GlobalPosition = GetRandomPosition();
            word.PathRotationDegrees = GD.RandRange(0, 360);
            word.WordStats = GetRandomType();

            _currentWords.Add(word.Text, word);
            AddChild(word);
        }

        public WordStats GetRandomType()
        {
            // this is basically a raffle where each word has <spawnrate>-many tickets inside the raffle. Winner is the one ticket that was actually drawn.
            var sum = WordPool.Aggregate(0, (acc, next) => acc + next.SpawnRate);
            var winner = _rng.RandiRange(0, sum - 1);
            int spawnRateSumToCurrentIndex = 0;
            for (int i = 0; i < WordPool.Length; i++)
            {
                spawnRateSumToCurrentIndex += WordPool[i].SpawnRate;
                if (winner < spawnRateSumToCurrentIndex)
                    return WordPool[i].Word;
            }
            throw new ShouldNeverHappenException(
                "This shouldn't happen by design of the raffle. If it does, the code is wrong."
            );
        }

        private Vector2 GetRandomPosition()
        {
            var dimensions = GetViewport().GetVisibleRect().Size;
            int marginBottom = 50;
            int marginRight = 200;
            int marginTop = 50;
            int marginLeft = 0;
            float x = GD.RandRange(marginLeft, (int)dimensions.X - marginRight);
            float y = GD.RandRange(marginTop, (int)dimensions.Y - marginBottom);
            return new Vector2(x, y);
        }

        public bool Has(string word) => _currentWords.ContainsKey(word);

        public void Remove(string str) => _currentWords.Remove(str);

        public void Kill(Word word)
        {
            _currentWords.Remove(word.Text);
            word.Die();
        }

        public Word GetWordOrDefault(string str) => _currentWords.GetValueOrDefault(str);

        private void _on_timer_timeout()
        {
            Spawn();
        }

        public void SpawnRegularly(float spawnIntervalInSec)
        {
            _timer.Start(spawnIntervalInSec);
        }
    }
}
