using Godot;
using System;

[Tool]
public partial class MyScore : MarginContainer, IHighscoreLabels, IWordsClearedScore, IComboMeterScore
{
	private string _value = "";
	private string _labelText = "";
	private string _color = "white";
	private int _valueFontSize = 16;
	private bool _rainbowEnabled = false;

	[ExportCategory("Scoring")]
	[Export]
	public string Value
	{
		get => _value;
		set
		{
			_value = value;
			UpdateAllLabels();
		}
	}

	[Export]
	public string Label
	{
		get => _labelText;
		set
		{
			_labelText = value;
			UpdateAllLabels();
		}
	}

	[Export]
	public string Color
	{
		get => _color;
		set
		{
			_color = value;
			UpdateAllLabels();
		}
	}

	[Export]
	public int ValueFontSize
	{
		get => _valueFontSize;
		set
		{
			_valueFontSize = value;
			UpdateAllLabels();
		}
	}

	[Export]
	public bool RainbowEnabled
	{
		get => _rainbowEnabled;
		set
		{
			_rainbowEnabled = value;
			UpdateAllLabels();
		}
	}

	private RichTextLabel _valueLabel;
	private Label _label;

	public override void _Ready()
	{
		_label = GetNode<Label>("H/Label");
		_valueLabel = GetNode<RichTextLabel>("H/Value");
		ValueFontSize = GetThemeDefaultFontSize();
		UpdateAllLabels();

	}

	private void UpdateAllLabels()
	{
		if (_valueLabel != null)
		{
			// rainbow and color are not compatible
			if (RainbowEnabled)
			{
				_valueLabel.Text = $"[rainbow freq=1.0 sat=0.8 val=0.8][font_size={ValueFontSize}]{Value}[/font_size][/rainbow]";
			}
			else
			{
				_valueLabel.Text = $"[font_size={ValueFontSize}][color={Color}]{Value}[/color][/font_size]";
			}
		}

		if (_label != null)
		{
			_label.Text = _labelText;
		}
	}


}
