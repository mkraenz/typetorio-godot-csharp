using System;
using Godot;


public partial class Word : Control
{
	private Resource _wordStatsRes;

	[Export]
	public string Text = "";

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
		setupWordStats();

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
		}
	}

	public void Die()
	{
		animation.Play("die");

		label.Material = GD.Load<Material>("res://effects/dissolve.material").Duplicate() as Material;
	}

	private void UpdateLabel()
	{
		int fontSize = (int)Math.Floor(GetThemeDefaultFontSize() * WordStats.FontScale);
		if (label != null)
		{
			label.Text = "";
			// label.Text = WordStats.Color == "rainbow" ? $"[rainbow freq=1.0 sat=0.8 val=0.8][font_size={fontSize}]{Text}[/font_size][/rainbow]" : $"[color={WordStats.Color}]{Text}[/color]";
			// label.PushColor();
			// if(WordStats.Color=="rainbow") label.PushT
			label.PushColor(WordStats.Color);
			label.PushFontSize(fontSize);

			switch (WordStats.SpecialEffects)
			{
				case SpecialEffect.Rainbow:
					// would love to use label.pushCustomFx(RainbowEffect, {freq: 1.0, ...}) but cant find RainbowEffect in Godot's C# APi. 	
					label.AppendText($"[rainbow freq=0.5 sat=1.0 val=0.8]{Text}[/rainbow]");
					break;
				case SpecialEffect.None:
					label.AppendText(Text);
					break;
			}

			label.PopAll();
		}

	}
}
