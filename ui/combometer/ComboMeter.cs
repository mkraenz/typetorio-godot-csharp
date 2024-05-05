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
		labels.Color = MultiplierColor(displayedMultiplier);
		labels.ValueFontSize = MultiplierFontSize(displayedMultiplier);
		labels.RainbowEnabled = displayedMultiplier >= 50;
	}

	int MultiplierFontSize(float displayedMultiplier) =>
		displayedMultiplier switch
		{
			> 49 => 48,
			> 24 => 32,
			> 16 => 28,
			> 10 => 24,
			> 6 => 20,
			> 3 => 18,
			_ => 16,
		};

	/// <summary>
	/// Relational Pattern matching https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching#relational-patterns */
	/// </summary>
	string MultiplierColor(float displayedMultiplier) =>
		displayedMultiplier switch
		{
			> 24 => "red",
			> 16 => "orange",
			> 10 => "yellow",
			> 6 => "green",
			> 3 => "blue",
			_ => "white",
		};


}
