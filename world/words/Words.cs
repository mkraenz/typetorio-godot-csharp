using Godot;
using System.Collections.Generic;
using System;

// TODO rename to WordSpawner
public partial class Words : Control
{
	[Export]
	private int _bonusWordInEveryNWords = 20;


	[Export]
	private int _maxConcurrentWords = 100;



	private Dictionary<string, Word> _currentWords = new Dictionary<string, Word> { };


	private string GetRandomWord()
	{
		string next = WordData.GetRandomWord();
		if (_currentWords.ContainsKey(next))
		{
			return GetRandomWord();
		}
		return next;
	}

	public void SpawnNewWord()
	{

		if (_currentWords.Count > _maxConcurrentWords) return;
		string nextWord = GetRandomWord();
		var WordScene = GD.Load<PackedScene>("res://ui/word/Word.tscn");
		var word = WordScene.Instantiate() as Word;
		word.Text = nextWord;
		word.GlobalPosition = GetRandomPosition();
		word.PathRotationDegrees = GD.RandRange(0, 360);
		var rand = GD.RandRange(0, _bonusWordInEveryNWords - 1);
		var rainbowWordStats = GD.Load<Resource>("res://ui/word/wordstats/RainbowWordStats.tres");
		if (rand == 0) word.WordStatsRes = rainbowWordStats;

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
}
