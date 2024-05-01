using Godot;
using System.Collections.Generic;

public partial class main : Node
{
	[Export]
	private int maxWords = 100;

	private Control words;
	private LineEdit lineEdit;

	private Dictionary<string, Node> _current_words = new Dictionary<string, Node> { };
	private int _points = 0;

	public override void _Ready()
	{
		words = GetNode<Control>("Gui/Words");
		lineEdit = GetNode<LineEdit>("Gui/InputBox/H/V/Input");
		lineEdit.GrabFocus();
	}

	private string _GetRandomWord()
	{
		string next = Words.GetRandomWord();
		if (_current_words.ContainsKey(next))
		{
			return _GetRandomWord();
		}
		return next;
	}

	public void _on_spawn_timer_timeout()
	{
		_SpawnNewWord();
	}

	private void _SpawnNewWord()
	{

		if (_current_words.Count > maxWords) return;
		string nextWord = _GetRandomWord();
		var label = new Label()
		{
			Text = nextWord,
			Position = _GetRandomPosition(),
		};
		_current_words.Add(label.Text, label);
		words.AddChild(label);
	}

	private Vector2 _GetRandomPosition()
	{
		int maxWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
		int maxHeight = (int)ProjectSettings.GetSetting("display/window/size/viewport_height");
		int marginBottom = 50;
		int marginRight = 200;
		float x = GD.RandRange(0, maxWidth - marginRight);
		float y = GD.RandRange(0, maxHeight - marginBottom);
		return new Vector2(x, y);
	}

	public void _on_line_edit_text_changed(string newText)
	{
		string str = newText.ToUpper();
		if (_current_words.ContainsKey(str))
		{
			Node label = _current_words.GetValueOrDefault(str);
			if (IsInstanceValid(label))
			{
				label.QueueFree();
				_current_words.Remove(str);
				_points++;
				GD.PrintT("Points", _points);
				lineEdit.Clear();
			}
			else
			{
				(label as Label).Text = str;
			}
		}
	}
}
