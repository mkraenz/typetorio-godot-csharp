using System;
using Globals;
using Godot;

namespace UI
{
    public partial class StartClassicSingleWordButton : Button
    {
        private Eventbus _eventbus;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _eventbus = GDAccessors.GetEventbus(this);
        }

        private void _on_pressed()
        {
            _eventbus.EmitStartClassicSingleWordGameClicked();
        }
    }
}
