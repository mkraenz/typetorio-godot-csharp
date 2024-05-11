using System;
using Godot;

namespace UI
{
    public partial class QuitButton : Button
    {
        private void _on_pressed()
        {
            GetTree().Quit();
        }
    }
}
