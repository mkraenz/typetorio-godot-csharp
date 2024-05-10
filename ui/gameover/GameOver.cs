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
	private AnimationPlayer _anims;

	public override void _Ready()
	{
		_eventbus = GDAccessors.GetEventbus(this);
		_points = GetNode<IPointsValue>("%PointsValue");
		_words = GetNode<IPointsValue>("%WordsValue");
		_maxCombo = GetNode<IPointsValue>("%ComboValue");
		_anims = GetNode<AnimationPlayer>("AnimationPlayer");

		_eventbus.GameEnded += OnGameEnded;
	}

	private void OnGameEnded(ScoreDto score)
	{
		_points.EndValue = score.Points;
		_words.EndValue = score.WordsCleared;
		_maxCombo.EndValue = score.MaxComboMultiplier;
	}

	private void _on_visibility_changed()
	{
		if (_anims != null && Visible)
		{
			_anims.Play("animate_points");
		}
	}
}
