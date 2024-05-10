using System;
using Godot;

public partial class main : Node
{
	private Eventbus _eventbus;
	private Control _mainMenu;
	private Control _hud;
	private Control _gameover;

	private PackedScene _WorldScene = ResourceLoader.Load<PackedScene>("res:///world/World.tscn");

	public override void _Ready()
	{
		_eventbus = GDAccessors.GetEventbus(this);
		_mainMenu = GetNode<Control>("Gui/MainMenu");
		_gameover = GetNode<Control>("Gui/GameOver");
		_hud = GetNode<Control>("Gui/Hud");
		_eventbus.StartClassicGameClicked += OnStartClassicGameClicked;
		_eventbus.BackToTitleClicked += OnBackToTitleClicked;
		_eventbus.GameEnded += OnGameEnded;
	}

	private void OnStartClassicGameClicked()
	{
		World world = _WorldScene.Instantiate<World>();
		AddChild(world);

		_hud.Show();
		_mainMenu.Hide();
		_gameover.Hide();
	}

	private void OnBackToTitleClicked()
	{
		_mainMenu.Show();
		_hud.Hide();
		_gameover.Hide();
	}

	private void OnGameEnded(Object _)
	{
		_mainMenu.Hide();
		_hud.Hide();
		_gameover.Show();
	}
}
