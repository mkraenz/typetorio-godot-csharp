using Godot;
using System;

public partial class ReadyGo : HBoxContainer
{
	[Signal]
	public delegate void AnimationFinishedEventHandler();

	private void _on_animation_player_animation_finished(string animName)
	{
		EmitSignal(SignalName.AnimationFinished);
	}
}
