using Godot;
using System;

public partial class Highscore : MarginContainer
{
	private int _score = 0;
	private Eventbus eventbus;
	private MyScore labels;

	public override void _Ready()
	{
		eventbus = GetNode<Eventbus>("/root/Eventbus");
		labels = GetNode<MyScore>("MyScore");

		eventbus.WordCleared += _OnWordCleared;
	}

	private void _OnWordCleared(string word)
	{
		_score++;
		labels.Value = _score.ToString();
	}
}
