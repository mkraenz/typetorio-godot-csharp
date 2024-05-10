using Godot;
using System;

public partial class Clock : Label
{
	private int _timeLeftInSec = 0;

	[Export]
	public int TimeLeftInSec
	{
		get => _timeLeftInSec;
		set
		{
			_timeLeftInSec = value;
			UpdateText();
		}
	}

	private Eventbus _eventbus;
	private Timer _timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_eventbus = GDAccessors.GetEventbus(this);
		_timer = GetNode<Timer>("Timer");

		_eventbus.GameStarted += OnGameStarted;
		UpdateText();
	}

	private void UpdateText()
	{
		var min = _timeLeftInSec / 60;
		var sec = _timeLeftInSec % 60;
		Text = $"{min.ToString("D2")}:{sec.ToString("D2")}";
	}

	private void OnGameStarted(string gameType, int gameTimeInSec)
	{
		TimeLeftInSec = gameTimeInSec;
		_timer.Start();
	}

	private void _on_timer_timeout()
	{
		TimeLeftInSec--;
	}
}
