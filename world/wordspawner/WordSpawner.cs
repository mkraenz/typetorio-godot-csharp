using System;
using System.Collections.Generic;
using Godot;

namespace World
{
    public partial class WordSpawner : Control
    {
        public GameSettings GameSettings { get; set; }

        private Dictionary<string, Word> _currentWords = new Dictionary<string, Word> { };

        private Timer _timer;

        private PackedScene _WordScene = ResourceLoader.Load<PackedScene>(
            "res://world/word/Word.tscn"
        );

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
            word.WordStats = GameSettings.WordDistribution.GetRandomType();

            _currentWords.Add(word.Text, word);
            AddChild(word);
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