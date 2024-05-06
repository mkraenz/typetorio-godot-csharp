using Godot;
using System;

public interface IPointsValue
{
	public int EndValue { set; }
}

public partial class GameOver : Control
{
	private Eventbus _eventbus;
	private IPointsValue _points;
	private IPointsValue _words;
	private IPointsValue _maxCombo;

	public override void _Ready()
	{
		_eventbus = GetNode<Eventbus>("/root/Eventbus");
		_points = GetNode<IPointsValue>("%PointsValue");
		_words = GetNode<IPointsValue>("%WordsValue");
		_maxCombo = GetNode<IPointsValue>("%ComboValue");

		_eventbus.GameEnded += OnGameEnded;
	}

	private void OnGameEnded(GameEnded data)
	{
		_points.EndValue = data.Points;
		_words.EndValue = data.Words;
		_maxCombo.EndValue = (int)data.ComboMultiplier;
	}
}
