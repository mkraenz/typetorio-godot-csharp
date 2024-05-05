using Godot;

public partial class main : Node
{
	private Eventbus _eventbus;
	private Control _mainMenu;

	public override void _Ready()
	{
		_eventbus = GetNode<Eventbus>("/root/Eventbus");
		_mainMenu = GetNode<Control>("Gui/MainMenu");
		_eventbus.StartClassicGameClicked += OnStartClassicGameClicked;
	}

	private void OnStartClassicGameClicked()
	{
		PackedScene World = GD.Load<PackedScene>("res:///world/World.tscn");
		World world = World.Instantiate<World>();
		AddChild(world);

		_mainMenu.Hide();
	}
}
