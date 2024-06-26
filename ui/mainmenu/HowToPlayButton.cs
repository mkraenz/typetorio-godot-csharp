using System;
using Globals;
using Godot;

namespace UI
{
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
}
