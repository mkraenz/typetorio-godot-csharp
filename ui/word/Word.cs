using System;
using System.IO;
using Godot;


[Tool]
public partial class Word : Control
{
	private bool _rainbowEnabled = false;
	private string _text = "";

	[Export]
	public string Text
	{
		get => _text;
		set
		{
			_text = value;
			UpdateLabel();
		}
	}

	[Export]
	public bool RainbowEnabled
	{
		get => _rainbowEnabled;
		set
		{
			_rainbowEnabled = value;
			UpdateLabel();
		}
	}


	public int PathRotationDegrees = 0;

	[Export]
	public Resource WordStatsRes;
	// duplicating the resource but with typings, so that clients can make use of it.
	public WordStats WordStats;

	private RichTextLabel label;
	private Path2D path;
	private AnimationPlayer animation;

	public override void _Ready()
	{
		if (!Engine.IsEditorHint())
		{
			setupWordStats();
		}

		animation = GetNode<AnimationPlayer>("AnimationPlayer");
		label = GetNode<RichTextLabel>("LabelWrapper/Label");
		path = GetNode<Path2D>("MoveInFigureEight");

		path.RotationDegrees = PathRotationDegrees;
		label.RotationDegrees = -PathRotationDegrees; // cancels out path rotation so that the actual word is readable as "normal" (left-to-right)

		UpdateLabel();

	}

	private void setupWordStats()
	{
		if (WordStatsRes is WordStats typedWordStats)
		{
			WordStats = typedWordStats;
			if (WordStats.ComboIncrease == 5)
			{
				RainbowEnabled = true;
			}
		}
		else throw new Exception("Missing WordStats on Word. Did you forget to set the resource in the Editor?");
	}

	public void Die()
	{
		animation.Play("die");

		label.Material = GD.Load<Material>("res://effects/dissolve.material").Duplicate() as Material;
	}

	private void UpdateLabel()
	{
		int fontSize = GetThemeDefaultFontSize() * 2;
		if (label != null)
		{
			label.Text = _rainbowEnabled ? $"[rainbow freq=1.0 sat=0.8 val=0.8][font_size={fontSize}]{Text}[/font_size][/rainbow]" : Text;
		}

	}
}
