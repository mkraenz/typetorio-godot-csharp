using System;
using Globals;
using Godot;

// TODO icon looks ugly as svg. the question mark is not fully rendered. fix it. maybe need to use png?
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
