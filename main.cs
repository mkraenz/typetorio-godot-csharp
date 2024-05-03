using Godot;
using System.Collections.Generic;

public partial class main : Node
{
	[Export]
	private int maxConcurrentWords = 100;


	private Control words;
	private InputPrompt prompt;
	private Eventbus eventbus;
	private Timer comboTimer;

	private Dictionary<string, Word> _current_words = new Dictionary<string, Word> { };
	private float _comboMultiplier = 0;

	public override void _Ready()
	{
		words = GetNode<Control>("Gui/Words");
		prompt = GetNode<InputPrompt>("Gui/InputBox/H/V/InputPrompt");
		eventbus = GetNode<Eventbus>("/root/Eventbus");
		comboTimer = GetNode<Timer>("ComboTimer");
		prompt.GrabFocus();

		_SpawnNewWord();
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

		if (_current_words.Count > maxConcurrentWords) return;
		string nextWord = _GetRandomWord();
		var WordScene = GD.Load<PackedScene>("res://ui/word/Word.tscn");
		var word = WordScene.Instantiate() as Word;
		word.Text = nextWord;
		word.GlobalPosition = _GetRandomPosition();
		word.PathRotationDegrees = GD.RandRange(0, 360);
		_current_words.Add(word.Text, word);
		words.AddChild(word); // force calling the ready function first
	}

	private Vector2 _GetRandomPosition()
	{
		int maxWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
		int maxHeight = (int)ProjectSettings.GetSetting("display/window/size/viewport_height");
		int marginBottom = 50;
		int marginRight = 200;
		int marginTop = 50;
		int marginLeft = 0;
		float x = GD.RandRange(marginLeft, maxWidth - marginRight);
		float y = GD.RandRange(marginTop, maxHeight - marginBottom);
		return new Vector2(x, y);
	}

	public void _on_line_edit_text_changed(string newText)
	{
		string str = newText.ToUpper();
		if (_current_words.ContainsKey(str))
		{
			Word word = _current_words.GetValueOrDefault(str);
			if (IsInstanceValid(word))
			{
				_CompleteWord(word, str);
			}
		}
		else
		{
			prompt.SetText(str);
		}
	}

	private void _CompleteWord(Word word, string str)
	{
		word.Die();
		_current_words.Remove(str);
		prompt.Clear();

		_comboMultiplier += 1;
		comboTimer.Start();
		eventbus.emitComboChanged(_comboMultiplier);

		// make sure to use the updated combo multiplier
		eventbus.EmitWordCleared(str, _comboMultiplier);

	}

	public void _on_combo_timer_timeout()
	{
		// reset combo
		_comboMultiplier = 0;
		eventbus.emitComboChanged(_comboMultiplier);
	}
}
