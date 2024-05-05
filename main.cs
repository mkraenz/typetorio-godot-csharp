using System;
using Godot;

public partial class main : Node
{
	private Eventbus _eventbus;
	private Control _mainMenu;
	private Control _hud;
	private Control _gameover;

	public override void _Ready()
	{
		_eventbus = GetNode<Eventbus>("/root/Eventbus");
		_mainMenu = GetNode<Control>("Gui/MainMenu");
		_gameover = GetNode<Control>("Gui/GameOver");
		_hud = GetNode<Control>("Gui/Hud");
		_eventbus.StartClassicGameClicked += OnStartClassicGameClicked;
		_eventbus.BackToTitleClicked += OnBackToTitleClicked;
		_eventbus.GameEnded += OnGameEnded;
	}

	private void OnStartClassicGameClicked()
	{
		PackedScene World = GD.Load<PackedScene>("res:///world/World.tscn");
		World world = World.Instantiate<World>();
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
