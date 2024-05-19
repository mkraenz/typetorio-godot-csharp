using System;
using Godot;

namespace UI
{
    [Tool]
    public partial class Title : MarginContainer
    {
        private Label _label;

        private string _text = "My Title";

        [Export]
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                if (_label != null)
                    _label.Text = _text;
            }
        }

        public override void _Ready()
        {
            _label = GetNode<Label>("Label");
            _label.Text = _text;
        }
    }
}
