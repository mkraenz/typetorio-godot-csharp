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

	private WordSpawner _words;
	private InputPrompt _prompt;
	private Eventbus _eventbus;
	private Timer _comboTimer;
	private Timer _gameTimer;

	private Score _score = new Score();


	public override void _Ready()
	{
		_words = GetNode<WordSpawner>("WordSpawner");
		_prompt = GetNode<InputPrompt>("%InputPrompt");
		_eventbus = GetNode<Eventbus>("/root/Eventbus");
		_comboTimer = GetNode<Timer>("ComboTimer");
		_gameTimer = GetNode<Timer>("GameTimer");
		_prompt.GrabFocus();

		_words.SpawnNewWord();
		_gameTimer.WaitTime = _gameTimeInSec;
		_gameTimer.Start();

		_eventbus.EmitGameStarted("classic", _gameTimeInSec);
	}

	public void _on_spawn_timer_timeout()
	{
		_words.SpawnNewWord();
	}


	public void _on_input_prompt_text_changed(string newText)
	{
		string str = newText.ToUpper();
		if (_words.Has(str))
		{
			Word word = _words.GetWordOrDefault(str);
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
		_words.Kill(word);
		_prompt.Clear();

		_score.CompleteWord(word.WordStats);
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
