using Godot;
using System.Collections.Generic;

public partial class World : CanvasLayer
{
	[Export]
	private int _bonusWordInEveryNWords = 20;

	[Export]
	private int _maxConcurrentWords = 100;


	[Export]
	private int _gameTimeInSec = 60;

	private Control _words;
	private InputPrompt _prompt;
	private Eventbus _eventbus;
	private Timer _comboTimer;
	private Timer _gameTimer;

	private Dictionary<string, Word> _currentWords = new Dictionary<string, Word> { };
	private Score _score = new Score();


	public override void _Ready()
	{
		_words = GetNode<Control>("Words");
		_prompt = GetNode<InputPrompt>("%InputPrompt");
		_eventbus = GetNode<Eventbus>("/root/Eventbus");
		_comboTimer = GetNode<Timer>("ComboTimer");
		_gameTimer = GetNode<Timer>("GameTimer");
		_prompt.GrabFocus();

		SpawnNewWord();
		_gameTimer.WaitTime = _gameTimeInSec;
		_gameTimer.Start();

		_eventbus.EmitGameStarted("classic", _gameTimeInSec);
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

	public void _on_input_prompt_text_changed(string newText)
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

		_score.CompleteWord(5, word.RainbowEnabled ? 5 : 1);
		_comboTimer.Start();
		_eventbus.EmitComboChanged(_score.ComboMultiplier);

		var scoreDto = new ScoreDto(_score);
		_eventbus.EmitWordCleared(str, scoreDto);
	}

	public void _on_combo_timer_timeout()
	{
		_score.ResetCombo();
		_eventbus.EmitComboChanged(_score.ComboMultiplier);
	}

	public void _on_game_timer_timeout()
	{
		EndGame();
	}

	private void EndGame()
	{
		var data = new ScoreDto(_score);
		_eventbus.EmitGameEnded(data);

		QueueFree();
	}
}
