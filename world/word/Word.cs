using System;
using Godot;

public partial class Word : Control
{
    [Export]
    public string Text = "";

    public int PathRotationDegrees = 0;

    [Export]
    public WordStats WordStats;

    private RichTextLabel label;
    private Path2D path;
    private AnimationPlayer animation;

    public override void _Ready()
    {
        animation = GetNode<AnimationPlayer>("AnimationPlayer");
        label = GetNode<RichTextLabel>("LabelWrapper/Label");
        path = GetNode<Path2D>("MoveInFigureEight");

        path.RotationDegrees = PathRotationDegrees;
        label.RotationDegrees = -PathRotationDegrees; // cancels out path rotation so that the actual word is readable as "normal" (left-to-right)

        UpdateLabel();
    }

    public void Die()
    {
        animation.Play("die");

        label.Material =
            GD.Load<Material>("res://effects/dissolve.material").Duplicate() as Material;
    }

    private void UpdateLabel()
    {
        int fontSize = (int)Math.Floor(GetThemeDefaultFontSize() * WordStats.FontScale);
        if (label != null)
        {
            label.Text = "";
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
