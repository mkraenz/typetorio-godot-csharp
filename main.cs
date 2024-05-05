using Godot;
using System.Collections.Generic;

public partial class main : Node
{
	[Export]
	private int _bonusWordInEveryNWords = 20;

	[Export]
	private int _maxConcurrentWords = 100;


	private Control _words;
	private InputPrompt _prompt;
	private Eventbus _eventbus;
	private Timer _comboTimer;

	private Dictionary<string, Word> _currentWords = new Dictionary<string, Word> { };
	private float _comboMultiplier = 0;

	public override void _Ready()
	{
		_words = GetNode<Control>("Gui/Words");
		_prompt = GetNode<InputPrompt>("Gui/InputBox/H/V/InputPrompt");
		_eventbus = GetNode<Eventbus>("/root/Eventbus");
		_comboTimer = GetNode<Timer>("ComboTimer");
		_prompt.GrabFocus();

		SpawnNewWord();
	}

	private string GetRandomWord()
	{
		string next = Words.GetRandomWord();
		if (_currentWords.ContainsKey(next))
		{
			return GetRandomWord();
		}
		return next;
	}

	public void _on_spawn_timer_timeout()
	{
		SpawnNewWord();
	}

	private void SpawnNewWord()
	{

		if (_currentWords.Count > _maxConcurrentWords) return;
		string nextWord = GetRandomWord();
		var WordScene = GD.Load<PackedScene>("res://ui/word/Word.tscn");
		var word = WordScene.Instantiate() as Word;
		word.Text = nextWord;
		word.GlobalPosition = GetRandomPosition();
		word.PathRotationDegrees = GD.RandRange(0, 360);
		var rand = GD.RandRange(0, _bonusWordInEveryNWords - 1);
		word.RainbowEnabled = rand == 0;
		_currentWords.Add(word.Text, word);
		_words.AddChild(word); // force calling the ready function first
	}

	private Vector2 GetRandomPosition()
	{
		var dimensions = GetViewport().GetVisibleRect().Size;
		int marginBottom = 50;
		int marginRight = 200;
		int marginTop = 50;
		int marginLeft = 0;
		float x = GD.RandRange(marginLeft, (int)dimensions.X - marginRight);
		float y = GD.RandRange(marginTop, (int)dimensions.Y - marginBottom);
		return new Vector2(x, y);
	}

	public void _on_line_edit_text_changed(string newText)
	{
		string str = newText.ToUpper();
		if (_currentWords.ContainsKey(str))
		{
			Word word = _currentWords.GetValueOrDefault(str);
			if (IsInstanceValid(word))
			{
				CompleteWord(word, str);
			}
		}
		else
		{
			_prompt.SetText(str);
		}
	}

	private void CompleteWord(Word word, string str)
	{
		word.Die();
		_currentWords.Remove(str);
		_prompt.Clear();

		_comboMultiplier += word.RainbowEnabled ? 5 : 1;
		_comboTimer.Start();
		_eventbus.EmitComboChanged(_comboMultiplier);

		// make sure to use the updated combo multiplier
		_eventbus.EmitWordCleared(str, _comboMultiplier);

	}

	public void _on_combo_timer_timeout()
	{
		// reset combo
		_comboMultiplier = 0;
		_eventbus.EmitComboChanged(_comboMultiplier);
	}
}
