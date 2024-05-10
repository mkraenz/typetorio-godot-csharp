using Godot;
using System.Collections.Generic;
using System;

public partial class WordSpawner : Control
{
	[Export]
	private int _bonusWordInEveryNWords = 20;

	[Export]
	public int MaxConcurrentWords = 100;

	private Dictionary<string, Word> _currentWords = new Dictionary<string, Word> { };

	private Timer _timer;

	private PackedScene _WordScene = ResourceLoader.Load<PackedScene>("res://ui/word/Word.tscn");
	private WordStats _rainbowWordStats = ResourceLoader.Load<WordStats>("res://ui/word/wordstats/RainbowWordStats.tres");

	public override void _Ready()
	{
		_timer = GetNode<Timer>("Timer");
	}


	private string GetRandomWord()
	{
		string next = WordData.GetRandomWord();
		if (_currentWords.ContainsKey(next))
		{
			return GetRandomWord();
		}
		return next;
	}

	public void Spawn()
	{

		if (_currentWords.Count >= MaxConcurrentWords) return;
		string nextWord = GetRandomWord();
		var word = _WordScene.Instantiate() as Word;
		word.Text = nextWord;
		word.GlobalPosition = GetRandomPosition();
		word.PathRotationDegrees = GD.RandRange(0, 360);
		var rand = GD.RandRange(0, _bonusWordInEveryNWords - 1);
		if (rand == 0) word.WordStats = _rainbowWordStats;

		_currentWords.Add(word.Text, word);
		AddChild(word);
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

	public bool Has(string word) => _currentWords.ContainsKey(word);
	public void Remove(string str) => _currentWords.Remove(str);
	public void Kill(Word word)
	{
		_currentWords.Remove(word.Text);
		word.Die();
	}
	public Word GetWordOrDefault(string str) => _currentWords.GetValueOrDefault(str);

	private void _on_timer_timeout()
	{
		Spawn();
	}

	public void SpawnRegularly(float spawnIntervalInSec)
	{
		_timer.Start(spawnIntervalInSec);
	}
}
