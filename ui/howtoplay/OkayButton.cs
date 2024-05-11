using System;
using Globals;
using Godot;

namespace UI
{
    public partial class OkayButton : Button
    {
        private Eventbus _eventbus;

        public override void _Ready()
        {
            _eventbus = GDAccessors.GetEventbus(this);
        }

        private void _on_pressed()
        {
            _eventbus.EmitBackToTitleClicked();
        }
    }
}
