using Godot;
using System;

public partial class PointsValue : Label
{
	[Export]
	public float _duration = 2;
	[Export]
	public int _currentValue = 0;
	[Export]
	public int _targetValue = 0;

	public void Animate()
	{
		var tween = CreateTween();
		tween.SetTrans(Tween.TransitionType.Linear);
		tween.SetEase(Tween.EaseType.InOut);
		tween.TweenMethod(Callable.From((float givenNumber) => UpdateCount(givenNumber)), _currentValue, _targetValue, _duration);
		tween.Play();
	}

	private void UpdateCount(float givenNumber)
	{
		var roundedNumber = (int)Math.Round(givenNumber);
		Text = roundedNumber.ToString("D6");
	}

	private void _on_visibility_changed()
	{
		if (Visible)
		{
			Animate();
		}
	}
}
