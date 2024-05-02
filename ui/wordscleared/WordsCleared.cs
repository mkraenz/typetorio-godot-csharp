using Godot;
using System;

public partial class WordsCleared : MarginContainer
{
	private Eventbus eventbus;
	private MyScore labels;
	private int _count = 0;

	public override void _Ready()
	{
		eventbus = GetNode<Eventbus>("/root/Eventbus");
		labels = GetNode<MyScore>("MyScore");

		eventbus.WordCleared += _OnWordCleared;
		_UpdateLabels();
	}

	private void _OnWordCleared(string word)
	{
		_count++;
		_UpdateLabels();
	}

	private void _UpdateLabels()
	{
		labels.Value = _count.ToString("D10");
	}
}
