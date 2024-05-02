using Godot;
using System;

[Tool]
public partial class MyScore : MarginContainer
{
	private string _value = "";
	private string _label = "";

	[ExportCategory("Scoring")]
	[Export]
	public string Value
	{
		get { return _value; }
		set
		{
			_value = value;
			_UpdateAllLabels();
		}
	}

	[Export]
	public string Label
	{
		get => _label;
		set
		{
			_label = value;
			_UpdateAllLabels();
		}
	}

	private Label valueLabel;
	private Label label;

	public override void _Ready()
	{
		label = GetNode<Label>("H/Label");
		valueLabel = GetNode<Label>("H/Value");
		_UpdateAllLabels();

	}

	private void _UpdateAllLabels()
	{
		if (valueLabel != null)
		{
			valueLabel.Text = _value;
		}

		if (label != null)
		{
			label.Text = _label;
		}
	}


}
