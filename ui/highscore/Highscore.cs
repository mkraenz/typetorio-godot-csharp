using Godot;
using System;

public interface IHighscoreLabels
{
	string Value { set; }
}


public partial class Highscore : MarginContainer
{
	private int _score = 0; // TODO remove
	private Eventbus _eventbus;
	private IHighscoreLabels _labels;

	public override void _Ready()
	{
		_eventbus = GetNode<Eventbus>("/root/Eventbus");
		_labels = GetNode<IHighscoreLabels>("MyScore");

		_eventbus.WordCleared += OnWordCleared;
		UpdateLabel();
	}

	private void OnWordCleared(string word, ScoreDto score)
	{
		_score = score.Points;
		UpdateLabel();
	}

	private void UpdateLabel()
	{
		_labels.Value = _score.ToString("D6"); // 10 digits with leading zeros
	}
}
