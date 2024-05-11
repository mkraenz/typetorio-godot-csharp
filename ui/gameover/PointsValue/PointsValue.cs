using System;
using Godot;

namespace UI
{
    public partial class PointsValue : Label, IPointsValue
    {
        [Export]
        public float Duration = 2;

        [Export]
        public int StartValue = 0;

        [Export]
        public int EndValue { get; set; } = 0;

        public void Animate()
        {
            var tween = CreateTween();
            tween.SetTrans(Tween.TransitionType.Linear);
            tween.SetEase(Tween.EaseType.InOut);
            tween.TweenMethod(
                Callable.From((float givenNumber) => UpdateCount(givenNumber)),
                StartValue,
                EndValue,
                Duration
            );
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
}
