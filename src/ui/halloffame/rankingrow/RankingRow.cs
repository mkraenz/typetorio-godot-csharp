using System;
using Godot;

namespace UI
{
    public partial class RankingRow : HBoxContainer
    {
        [Export]
        public int Rank { get; set; } = 0;

        [Export]
        public string Username { get; set; } = "Username";

        [Export]
        public int Score { get; set; } = 0;

        private Label _rankLabel;
        private Label _nameLabel;
        private Label _scoreLabel;

        public override void _Ready()
        {
            _rankLabel = GetNode<Label>("Rank");
            _nameLabel = GetNode<Label>("Name");
            _scoreLabel = GetNode<Label>("Score");

            Redraw();
        }

        private void Redraw()
        {
            _rankLabel.Text = Rank.ToString("D2");
            _nameLabel.Text = Username;
            _scoreLabel.Text = Score.ToString("D6");
        }
    }
}
