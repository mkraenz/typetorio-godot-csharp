using System;
using Globals;
using Godot;

namespace UI
{
    public partial class StartClassicGame : Button
    {
        private Eventbus _eventbus;

        public override void _Ready()
        {
            _eventbus = GDAccessors.GetEventbus(this);
        }

        public void _on_pressed()
        {
            _eventbus.EmitStartClassicGameClicked();
        }
    }
}
