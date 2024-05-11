using Godot;
using System;

namespace UI
{
	public partial class ShopItem : PanelContainer
	{
		[Export] private Texture2D _icon;

		[Export(PropertyHint.MultilineText)] private string _text;
		[Export] private string _tooltip;

		private bool soldOut;

		private Label _label;
		private TextureRect _iconTexture;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			_label = GetNode<Label>("V/Label");
			_iconTexture = GetNode<TextureRect>("V/H/Icon");

			_iconTexture.Texture = _icon;
			_label.Text = _text;
			TooltipText = _tooltip;

			if (soldOut)
			{
				MouseDefaultCursorShape = CursorShape.Forbidden;
				_iconTexture.Modulate = Colors.DimGray;
				_label.Modulate = Colors.DimGray;
			}
		}
	}

}