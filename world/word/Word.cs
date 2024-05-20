using System;
using Dtos;
using Godot;

namespace World
{
    public partial class Word : Control
    {
        [Export]
        public string Text { get; set; } = "";

        public int PathRotationDegrees { get; set; }

        [Export]
        public WordStats WordStats { get; set; }

        private RichTextLabel _label;
        private Path2D _path;
        private RichTextLabel _pointsOnDeath;
        private AnimationPlayer _anims;

        public override void _Ready()
        {
            _anims = GetNode<AnimationPlayer>("AnimationPlayer");
            _label = GetNode<RichTextLabel>("LabelWrapper/Label");
            _path = GetNode<Path2D>("MoveInFigureEight");
            _pointsOnDeath = GetNode<RichTextLabel>("%Points");

            _path.RotationDegrees = PathRotationDegrees;

            UpdateLabel();
        }

        public void Die(IScore score)
        {
            _pointsOnDeath.Text = "";
            _pointsOnDeath.PushColor(Colors.Green);
            _pointsOnDeath.AppendText($"+{score.PointsIncrease.ToString()}");
            _pointsOnDeath.Show();
            _anims.Play("die");

            _label.Material =
                GD.Load<Material>("res://effects/dissolve.material").Duplicate() as Material;
        }

        private void UpdateLabel()
        {
            int fontSize = (int)Math.Floor(GetThemeDefaultFontSize() * WordStats.FontScale);
            if (_label != null)
            {
                _label.Text = "";
                _label.PushColor(WordStats.Color);
                _label.PushFontSize(fontSize);

                switch (WordStats.SpecialEffects)
                {
                    case SpecialEffect.Rainbow:
                        // would love to use label.pushCustomFx(RainbowEffect, {freq: 1.0, ...}) but cant find RainbowEffect in Godot's C# APi.
                        _label.AppendText($"[rainbow freq=0.5 sat=1.0 val=0.8]{Text}[/rainbow]");
                        break;
                    case SpecialEffect.None:
                        _label.AppendText(Text);
                        break;
                }

                _label.PopAll();
            }
        }
    }
}
