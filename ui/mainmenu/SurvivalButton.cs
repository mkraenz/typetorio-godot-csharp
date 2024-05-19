using Globals;
using Godot;

namespace UI
{

	public partial class SurvivalButton : Button
	{
		private Eventbus _eventbus;

		public override void _Ready()
		{
			_eventbus = GDAccessors.GetEventbus(this);
		}

		private void _on_pressed()
		{
			_eventbus.EmitStartSurvivalModeClicked();
		}
	}

}