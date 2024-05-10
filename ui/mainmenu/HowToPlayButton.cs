using Godot;
using System;

public partial class HowToPlayButton : Button
{

	private Eventbus _eventbus;

	public override void _Ready()
	{
		_eventbus = GDAccessors.GetEventbus(this);
	}

	private void _on_pressed()
	{
		_eventbus.EmitHowToPlayPressed();
	}
}
