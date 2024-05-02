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
		_UpdateLabel();
	}

	private void _OnWordCleared(string word, float comboMultiplier)
	{
		_score += (int)(5 * comboMultiplier);
		_UpdateLabel();
	}

	private void _UpdateLabel()
	{
		labels.Value = _score.ToString("D10"); // 10 digits with leading zeros
	}
}
