using System;
using Globals;
using Godot;

namespace UI
{
    public partial class ShopItem : PanelContainer
    {
        [Export]
        private Texture2D _icon;

        [Export(PropertyHint.MultilineText)]
        private string _text;

        [Export]
        private string _tooltip;

        [Export]
        private int _priceInPoints;

        [Export]
        private Unlocks _feature;

        private Label _label;
        private TextureRect _iconTexture;

        private GameProgress _gameProgress;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _gameProgress = GDAccessors.GetGameProgress(this);
            _label = GetNode<Label>("V/Label");
            _iconTexture = GetNode<TextureRect>("V/H/Icon");

            _iconTexture.Texture = _icon;
            _label.Text = $"{_text}\n$ {_priceInPoints}";
            TooltipText = _tooltip;

            if (_gameProgress.HasUnlocked(_feature))
            {
                DisplayAsSoldOut();
            }
        }

        public override void _GuiInput(InputEvent @event)
        {
            base._GuiInput(@event);
            if (@event is InputEventMouseButton mb)
            {
                if (mb.ButtonIndex == MouseButton.Left && mb.Pressed)
                {
                    Buy();
                }
            }
        }

        private void Buy()
        {
            var price = _priceInPoints;
            if (!_gameProgress.CanAfford(price))
                return;
            _gameProgress.Buy(_feature, price);
            DisplayAsSoldOut();
        }

        private void DisplayAsSoldOut()
        {
            MouseDefaultCursorShape = CursorShape.Forbidden;
            _iconTexture.Modulate = Colors.DimGray;
            _label.Modulate = Colors.DimGray;
            MouseFilter = MouseFilterEnum.Ignore;
        }
    }
}
