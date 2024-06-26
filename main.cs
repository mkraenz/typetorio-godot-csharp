using System;
using System.Threading.Tasks;
using Globals;
using Godot;
using World;
using MyWorld = World.World;

namespace Main
{
    public partial class main : Node
    {
        private SceneTransition _sceneTransition;
        private Eventbus _eventbus;
        private Control _mainMenu;
        private Control _hud;
        private Control _gameover;
        private Control _howToPlay;
        private Control _hallOfFame;
        private Control _shop;

        private PackedScene _WorldScene = ResourceLoader.Load<PackedScene>(
            "res://world/World.tscn"
        );
        private PackedScene _SurvivalWorldScene = ResourceLoader.Load<PackedScene>(
            "res://src/modes/survival/SurvivalWorld.tscn"
        );
        private PackedScene _PainfulTyposWorld = ResourceLoader.Load<PackedScene>(
            "res://src/modes/painfultypos/PainfulTyposWorld.tscn"
        );

        public override void _Ready()
        {
            _eventbus = GDAccessors.GetEventbus(this);
            _sceneTransition = GDAccessors.GetSceneTransition(this);
            _mainMenu = GetNode<Control>("Gui/MainMenu");
            _gameover = GetNode<Control>("Gui/GameOver");
            _howToPlay = GetNode<Control>("Gui/HowToPlay");
            _shop = GetNode<Control>("Gui/ShopMenu");
            _hud = GetNode<Control>("Gui/Hud");
            _hallOfFame = GetNode<Control>("Gui/HallOfFame");
            _eventbus.StartClassicGameClicked += OnStartClassicGameClicked;
            _eventbus.StartSurvivalModeClicked += OnStartSurvivalModeClicked;
            _eventbus.StartClassicSingleWordGameClicked += OnStartClassicSingleWordGameClicked;
            _eventbus.StartPainfulTyposModeClicked += OnStartPainfulTyposModeClicked;
            _eventbus.BackToTitleClicked += OnBackToTitleClicked;
            _eventbus.HowToPlayPressed += OnHowToPlayPressed;
            _eventbus.GameEnded += OnGameEnded;
            _eventbus.ShopButtonPressed += OnShopButtonPressed;
            _eventbus.HallOfFameClicked += OnHallOfFameClicked;
        }

        private async void OnHallOfFameClicked()
        {
            await HideScreens();
            _hallOfFame.Show();
        }

        private async void OnStartClassicGameClicked()
        {
            MyWorld world = _WorldScene.Instantiate<MyWorld>();
            await HideScreens();
            AddChild(world);
            _hud.Show();
        }

        private async void OnStartClassicSingleWordGameClicked()
        {
            MyWorld world = _WorldScene.Instantiate<MyWorld>();
            world.GameSettings = GD.Load<GameSettings>(
                "res://world/gamesettings/SingleWordGameSettings.tres"
            );
            AddChild(world);

            await HideScreens();
            _hud.Show();
        }

        private async void OnStartSurvivalModeClicked()
        {
            SurvivalWorld world = _SurvivalWorldScene.Instantiate<SurvivalWorld>();
            AddChild(world);

            await HideScreens();
            _hud.Show();
        }

        private async void OnStartPainfulTyposModeClicked()
        {
            PainfulTyposWorld world = _PainfulTyposWorld.Instantiate<PainfulTyposWorld>();
            AddChild(world);

            await HideScreens();
            _hud.Show();
        }

        private async Task HideScreens()
        {
            _sceneTransition.DiagonalSlideIn();
            await ToSignal(_sceneTransition, SceneTransition.SignalName.AnimationFinished);
            _mainMenu.Hide();
            _gameover.Hide();
            _howToPlay.Hide();
            _hud.Hide();
            _shop.Hide();
            _hallOfFame.Hide();
            _sceneTransition.DiaonalSlideOut();
        }

        private async void OnBackToTitleClicked()
        {
            await HideScreens();
            _mainMenu.Show();
        }

        private async void OnGameEnded(Object _)
        {
            await HideScreens();
            _gameover.Show();
        }

        private async void OnHowToPlayPressed()
        {
            await HideScreens();
            _howToPlay.Show();
        }

        private async void OnShopButtonPressed()
        {
            await HideScreens();
            _shop.Show();
        }
    }
}
