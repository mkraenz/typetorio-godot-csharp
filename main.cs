using System;
using Globals;
using Godot;
using World;
using MyWorld = World.World;

namespace Main
{
    public partial class main : Node
    {
        private Eventbus _eventbus;
        private Control _mainMenu;
        private Control _hud;
        private Control _gameover;
        private Control _howToPlay;
        private Control _shop;

        private PackedScene _WorldScene = ResourceLoader.Load<PackedScene>(
            "res:///world/World.tscn"
        );

        public override void _Ready()
        {
            _eventbus = GDAccessors.GetEventbus(this);
            _mainMenu = GetNode<Control>("Gui/MainMenu");
            _gameover = GetNode<Control>("Gui/GameOver");
            _howToPlay = GetNode<Control>("Gui/HowToPlay");
            _shop = GetNode<Control>("Gui/ShopMenu");
            _hud = GetNode<Control>("Gui/Hud");
            _eventbus.StartClassicGameClicked += OnStartClassicGameClicked;
            _eventbus.StartClassicSingleWordGameClicked += OnStartClassicSingleWordGameClicked;
            _eventbus.BackToTitleClicked += OnBackToTitleClicked;
            _eventbus.HowToPlayPressed += OnHowToPlayPressed;
            _eventbus.GameEnded += OnGameEnded;
            _eventbus.ShopButtonPressed += OnShopButtonPressed;
        }

        private void OnStartClassicGameClicked()
        {
            MyWorld world = _WorldScene.Instantiate<MyWorld>();
            var wordDistribution = (WordDistribution)ResourceLoader.Load<WordDistribution>("res://world/worddistribution/DefaultWordDistribution.tres").Duplicate();
            var _gameProgress = GDAccessors.GetGameProgress(this);
            if (_gameProgress.HasUnlocked(Unlocks.BlueWord)) wordDistribution.Blue = 50;
            if (_gameProgress.HasUnlocked(Unlocks.RainbowWord)) wordDistribution.Rainbow = 25;
            // wordDistribution.Default = 0;
            world.GameSettings.WordDistribution = wordDistribution; // Does this change the cached game settings?


            AddChild(world);

            HideScreens();
            _hud.Show();
        }

        private void OnStartClassicSingleWordGameClicked()
        {
            MyWorld world = _WorldScene.Instantiate<MyWorld>();
            world.GameSettings = GD.Load<GameSettings>(
                "res://world/gamesettings/SingleWordGameSettings.tres"
            );
            AddChild(world);

            HideScreens();
            _hud.Show();
        }

        private void HideScreens()
        {
            _mainMenu.Hide();
            _gameover.Hide();
            _howToPlay.Hide();
            _hud.Hide();
            _shop.Hide();
        }

        private void OnBackToTitleClicked()
        {
            HideScreens();
            _mainMenu.Show();
        }

        private void OnGameEnded(Object _)
        {
            HideScreens();
            _gameover.Show();
        }

        private void OnHowToPlayPressed()
        {
            HideScreens();
            _howToPlay.Show();
        }

        private void OnShopButtonPressed()
        {
            HideScreens();
            _shop.Show();
        }
    }
}
