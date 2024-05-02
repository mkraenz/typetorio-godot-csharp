using Godot;
using System;

public partial class ComboMeter : MarginContainer
{
	private Eventbus eventbus;
	private MyScore labels;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		eventbus = GetNode<Eventbus>("/root/Eventbus");
		labels = GetNode<MyScore>("MyScore");

		eventbus.ComboChanged += _OnComboChanged;
		labels.Value = "x1";
	}

	private void _OnComboChanged(float multiplier)
	{
		float displayedMultiplier = multiplier == 0 ? 1 : multiplier;
		string val = ((int)displayedMultiplier).ToString();
		labels.Value = $"x{val}";
	}
}
