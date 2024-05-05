using Godot;
using System;

public partial class GameOver : Control
{
	private Eventbus _eventbus;
	private PointsValue _points;
	private Label _words;
	private Label _maxCombo;

	public override void _Ready()
	{
		_eventbus = GetNode<Eventbus>("/root/Eventbus");
		_points = GetNode<PointsValue>("%PointsValue");
		_words = GetNode<Label>("%WordsValue");
		_maxCombo = GetNode<Label>("%ComboValue");

		_eventbus.GameEnded += OnGameEnded;
	}

	private void OnGameEnded(GameEnded data)
	{
		_points._targetValue = data.Points;
		// _points.Text = ((int)data.Points).ToString("D6");
		_words.Text = ((int)data.Words).ToString("D6");
		_maxCombo.Text = ((int)data.ComboMultiplier).ToString("D6");
	}
}
