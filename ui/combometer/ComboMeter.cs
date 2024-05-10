using Godot;
using System;

public interface IComboMeterScore
{
	string Value { set; }
	int ValueFontSize { set; }
	string Color { set; }
	bool RainbowEnabled { set; }
}

public partial class ComboMeter : MarginContainer
{
	private Eventbus _eventbus;
	private IComboMeterScore _labels;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_eventbus = GDAccessors.GetEventbus(this);
		_labels = GetNode<IComboMeterScore>("MyScore");

		_eventbus.ComboChanged += OnComboChanged;
		_eventbus.GameAboutToStart += Reset;
	}

	private void Reset()
	{
		OnComboChanged(0);
	}

	private void OnComboChanged(int multiplier)
	{
		int displayedMultiplier = multiplier == 0 ? 1 : multiplier;
		string val = displayedMultiplier.ToString();
		_labels.Value = $"x{val}";
		_labels.Color = MultiplierColor(displayedMultiplier);
		_labels.ValueFontSize = MultiplierFontSize(displayedMultiplier);
		_labels.RainbowEnabled = displayedMultiplier >= 50;
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
