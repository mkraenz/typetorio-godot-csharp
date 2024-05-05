using Godot;

public partial class main : Node
{
	private Eventbus _eventbus;

	public override void _Ready()
	{
		PackedScene World = GD.Load<PackedScene>("res:///world/World.tscn");
		World world = World.Instantiate<World>();
		AddChild(world);
	}
}
