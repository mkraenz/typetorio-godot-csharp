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
	private int _count = 0;

	public override void _Ready()
	{
		_eventbus = GetNode<Eventbus>("/root/Eventbus");
		_labels = GetNode<IWordsClearedScore>("MyScore");

		_eventbus.WordCleared += OnWordCleared;
		UpdateLabels();
	}

	private void OnWordCleared(string word, float comboMultiplier)
	{
		_count++;
		UpdateLabels();
	}

	private void UpdateLabels()
	{
		_labels.Value = _count.ToString("D6");
	}
}
