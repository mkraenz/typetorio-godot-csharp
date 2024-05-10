using System;
using Godot;

public partial class main : Node
{
	private Eventbus _eventbus;
	private Control _mainMenu;
	private Control _hud;
	private Control _gameover;
	private Control _howToPlay;

	private PackedScene _WorldScene = ResourceLoader.Load<PackedScene>("res:///world/World.tscn");

	public override void _Ready()
	{
		_eventbus = GDAccessors.GetEventbus(this);
		_mainMenu = GetNode<Control>("Gui/MainMenu");
		_gameover = GetNode<Control>("Gui/GameOver");
		_howToPlay = GetNode<Control>("Gui/HowToPlay");
		_hud = GetNode<Control>("Gui/Hud");
		_eventbus.StartClassicGameClicked += OnStartClassicGameClicked;
		_eventbus.StartClassicSingleWordGameClicked += OnStartClassicSingleWordGameClicked;
		_eventbus.BackToTitleClicked += OnBackToTitleClicked;
		_eventbus.HowToPlayPressed += OnHowToPlayPressed;
		_eventbus.GameEnded += OnGameEnded;
	}

	private void OnStartClassicGameClicked()
	{
		World world = _WorldScene.Instantiate<World>();
		AddChild(world);

		_hud.Show();
		_mainMenu.Hide();
		_gameover.Hide();
		_howToPlay.Hide();
	}

	private void OnStartClassicSingleWordGameClicked()
	{

		World world = _WorldScene.Instantiate<World>();
		world.GameSettings = GD.Load<GameSettings>("res://world/gamesettings/SingleWordGameSettings.tres");
		AddChild(world);

		_hud.Show();
		_mainMenu.Hide();
		_gameover.Hide();
		_howToPlay.Hide();
	}

	// TODO use
	private void HideScreens()
	{
		_mainMenu.Hide();
		_gameover.Hide();
		_howToPlay.Hide();
		_hud.Hide();
	}

	private void OnBackToTitleClicked()
	{
		_mainMenu.Show();
		_hud.Hide();
		_gameover.Hide();
		_howToPlay.Hide();
	}

	private void OnGameEnded(Object _)
	{
		_howToPlay.Hide();
		_mainMenu.Hide();
		_hud.Hide();
		_gameover.Show();
	}

	private void OnHowToPlayPressed()
	{
		_howToPlay.Show();
		_mainMenu.Hide();
		_hud.Hide();
		_gameover.Hide();
	}
}
