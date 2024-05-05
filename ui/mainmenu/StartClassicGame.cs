using Godot;
using System;

public partial class StartClassicGame : Button
{
	private Eventbus _eventbus;

	public override void _Ready()
	{
		_eventbus = GetNode<Eventbus>("/root/Eventbus");
	}

	public void _on_pressed()
	{
		_eventbus.EmitStartClassicGameClicked();
	}
}
