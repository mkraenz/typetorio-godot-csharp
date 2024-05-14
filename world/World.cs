using System.Collections.Generic;
using System.Linq;
using Dtos;
using Globals;
using Godot;

namespace World
{
    public partial class World : CanvasLayer
    {
        [Export]
        public GameSettings GameSettings { get; set; }

        private WordSpawner _words;
        private InputPrompt _prompt;
        private Eventbus _eventbus;
        private Timer _comboTimer;
        private Timer _gameTimer;

        private Score _score = new Score();

        public override void _Ready()
        {
            _eventbus = GDAccessors.GetEventbus(this);
            _words = GetNode<WordSpawner>("WordSpawner");
            _prompt = GetNode<InputPrompt>("%InputPrompt");
            _comboTimer = GetNode<Timer>("ComboTimer");
            _gameTimer = GetNode<Timer>("GameTimer");
            _prompt.GrabFocus();

            InitWordSpawner();
            _gameTimer.WaitTime = GameSettings.GameTimeInSec;

            _eventbus.EmitGameAboutToStart();
        }

        private void InitWordSpawner()
        {
            var defaultWord = GD.Load<WordStats>(
                "res://world/word/wordstats/DefaultWordStats.tres"
            );
            var blueWord = GD.Load<WordStats>("res://world/word/wordstats/SkyblueWordStats.tres");
            var rainbowWord = GD.Load<WordStats>(
                "res://world/word/wordstats/RainbowWordStats.tres"
            );
            var allWordTypes = new List<WordStats> { };
            var _gameProgress = GDAccessors.GetGameProgress(this);
            if (_gameProgress.HasUnlocked(Unlocks.BlueWord))
                allWordTypes.Add(blueWord);
            if (_gameProgress.HasUnlocked(Unlocks.RainbowWord))
                allWordTypes.Add(rainbowWord);
            if (!_gameProgress.HasUnlocked(Unlocks.NoDefaultWords))
                allWordTypes.Add(defaultWord);

            if (allWordTypes.Count == 0)
                allWordTypes = new List<WordStats> { defaultWord };

            var wordPool = (
                from wordStats in allWordTypes
                select (new Spawn(wordStats, wordStats.BaseSpawnRate))
            ).ToArray();

            _words.GameSettings = GameSettings;
            _words.WordPool = wordPool;
        }

        private void StartGame()
        {
            _words.Spawn();
            _gameTimer.Start();
            _words.SpawnRegularly(GameSettings.SpawnIntervalInSec);

            _eventbus.EmitGameStarted("classic", GameSettings.GameTimeInSec);
        }

        private void _on_ready_go_animation_finished()
        {
            StartGame();
        }

        public void _on_input_prompt_text_changed(string newText)
        {
            string str = newText.ToUpperInvariant();
            if (_words.Has(str))
            {
                Word word = _words.GetWordOrDefault(str);
                if (IsInstanceValid(word))
                {
                    CompleteWord(word, str);
                }
            }
            else
            {
                _prompt.SetText(str);
            }
        }

        private void CompleteWord(Word word, string str)
        {
            _words.Kill(word);
            _prompt.Clear();

            _score.CompleteWord(word.WordStats);
            _comboTimer.Start();
            _eventbus.EmitComboChanged(_score.ComboMultiplier);

            var scoreDto = new ScoreDto(_score);
            _eventbus.EmitWordCleared(str, scoreDto);
        }

        public void _on_combo_timer_timeout()
        {
            _score.ResetCombo();
            _eventbus.EmitComboChanged(_score.ComboMultiplier);
        }

        public void _on_game_timer_timeout()
        {
            EndGame();
        }

        private void EndGame()
        {
            var data = new ScoreDto(_score);
            _eventbus.EmitGameEnded(data);

            QueueFree();
        }
    }
}
