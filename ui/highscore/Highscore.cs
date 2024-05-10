using Godot;
using System;

public interface IHighscoreLabels
{
	string Value { set; }
}


public partial class Highscore : MarginContainer
{
	private Eventbus _eventbus;
	private IHighscoreLabels _labels;

	public override void _Ready()
	{
		_eventbus = GDAccessors.GetEventbus(this);
		_labels = GetNode<IHighscoreLabels>("MyScore");

		_eventbus.WordCleared += OnWordCleared;
	}

	private void OnWordCleared(string word, ScoreDto score)
	{
		_labels.Value = score.Points.ToString("D6"); // 10 digits with leading zeros
	}
}
