using Globals;
using Godot;
using System;

namespace UI
{
	public partial class BackToMainMenuButton : Button
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
