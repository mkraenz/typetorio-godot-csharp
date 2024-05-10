using Godot;
using System;

public partial class QuitButton : Button
{
	private void _on_pressed()
	{
		GetTree().Quit();
	}
}
