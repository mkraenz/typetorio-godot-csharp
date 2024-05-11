using System;
using Godot;

public partial class QuitButton : Button
{
    private void _on_pressed()
    {
        GetTree().Quit();
    }
}
