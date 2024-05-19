using System;
using Dtos;
using Godot;
using UnlocksDict = Godot.Collections.Dictionary<string, Godot.Variant>;

namespace Globals
{
    public partial class Eventbus : Node
    {
        [Signal]
        public delegate void WordClearedEventHandler(string word, ScoreDto score);

        [Signal]
        public delegate void ComboChangedEventHandler(int comboMultiplier);

        [Signal]
        public delegate void StartClassicGameClickedEventHandler();

        [Signal]
        public delegate void StartClassicSingleWordGameClickedEventHandler();
        [Signal]
        public delegate void StartSurvivalModeClickedEventHandler();

        [Signal]
        public delegate void GameEndedEventHandler(ScoreDto score);

        [Signal]
        public delegate void BackToTitleClickedEventHandler();

        [Signal]
        public delegate void GameStartedEventHandler(string gameType, int gameTimeInSec);

        [Signal]
        public delegate void GameAboutToStartEventHandler();

        [Signal]
        public delegate void HowToPlayPressedEventHandler();

        [Signal]
        public delegate void ShopButtonPressedEventHandler();

        [Signal]
        public delegate void UnlocksChangedEventHandler(UnlocksDict unlocks);
        [Signal] public delegate void GameTimeChangedEventHandler(float timeLeft);

        public void EmitWordCleared(string word, ScoreDto score)
        {
            EmitSignal(SignalName.WordCleared, word, score);
        }

        public void EmitComboChanged(int comboMultiplier)
        {
            EmitSignal(SignalName.ComboChanged, comboMultiplier);
        }

        public void EmitStartClassicGameClicked()
        {
            EmitSignal(SignalName.StartClassicGameClicked);
        }

        public void EmitStartClassicSingleWordGameClicked()
        {
            EmitSignal(SignalName.StartClassicSingleWordGameClicked);
        }

        public void EmitGameEnded(ScoreDto score)
        {
            EmitSignal(SignalName.GameEnded, score);
        }

        public void EmitBackToTitleClicked()
        {
            EmitSignal(SignalName.BackToTitleClicked);
        }

        internal void EmitGameStarted(string gameType, int gameTimeInSec)
        {
            EmitSignal(SignalName.GameStarted, gameType, gameTimeInSec);
        }

        internal void EmitGameAboutToStart()
        {
            EmitSignal(SignalName.GameAboutToStart);
        }

        internal void EmitHowToPlayPressed()
        {
            EmitSignal(SignalName.HowToPlayPressed);
        }

        internal void EmitShopButtonPressed()
        {
            EmitSignal(SignalName.ShopButtonPressed);
        }

        internal void EmitUnlocksChanged(UnlocksDict unlocks)
        {
            EmitSignal(SignalName.UnlocksChanged, unlocks);
        }

        internal void EmitStartSurvivalModeClicked()
        {
            EmitSignal(SignalName.StartSurvivalModeClicked);
        }

        internal void EmitGameTimeChanged(float timeLeft)
        {
            EmitSignal(SignalName.GameTimeChanged, timeLeft);
        }
    }
}
