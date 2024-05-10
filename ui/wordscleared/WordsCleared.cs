using Godot;
using System;

public interface IWordsClearedScore
{
	string Value { set; }
}

public partial class WordsCleared : MarginContainer
{
	private Eventbus _eventbus;
	private IWordsClearedScore _labels;

	public override void _Ready()
	{
		_eventbus = GDAccessors.GetEventbus(this);
		_labels = GetNode<IWordsClearedScore>("MyScore");

		_eventbus.WordCleared += OnWordCleared;
	}

	private void OnWordCleared(string word, ScoreDto score)
	{
		_labels.Value = score.WordsCleared.ToString("D6");
	}

}
