using System;
using Godot;

namespace Globals
{
    public partial class SceneTransition : CanvasLayer
    {
        [Signal]
        public delegate void AnimationFinishedEventHandler(string animationName);
        private ColorRect _rect;

        public override void _Ready()
        {
            base._Ready();
            _rect = GetNode<ColorRect>("ColorRect");
        }

        public void DiagonalSlideIn()
        {
            var dim = GetViewport().GetVisibleRect().Size;
            var direction = dim;
            _rect.Rotation = direction.Angle();
            _rect.Size = new Vector2(0, 2 * dim.Length()); // doubling y to cover the whole screen
            _rect.Modulate = Colors.White;
            _rect.GlobalPosition = dim.Orthogonal();
            var tween = CreateTween();
            tween.TweenMethod(
                Callable.From((float progress) => ProgressDiagonalSlideIn(progress)),
                0f,
                1f,
                0.3
            );
            tween.Play();
            tween.Finished += () =>
            {
                EmitSignal(SignalName.AnimationFinished, "DiagonalSlideIn");
            };
        }

        public void DiaonalSlideOut()
        {
            var dim = GetViewport().GetVisibleRect().Size;
            var direction = dim;
            _rect.Rotation = direction.Angle();
            _rect.Modulate = Colors.White;
            _rect.GlobalPosition = dim.Orthogonal();
            _rect.Size = new Vector2(dim.Length(), 2 * dim.Length());
            var tween = CreateTween();
            tween.TweenMethod(
                Callable.From((float progress) => ProgressDiagonalSlideOut(progress)),
                0f,
                1f,
                0.3
            );
            tween.Play();
            tween.Finished += () =>
            {
                _rect.Size = new Vector2(0, 2 * dim.Length()); // not sure whether godot guarantees that the tweened method gets called with the start and end values. Hence this extra call to ensure we hide the rect eventually.
                EmitSignal(SignalName.AnimationFinished, "DiagonalSlideIn");
            };
        }

        private void ProgressDiagonalSlideOut(float progress)
        {
            var dim = GetViewport().GetVisibleRect().Size;
            _rect.GlobalPosition = dim * progress + dim.Orthogonal();
        }

        private void ProgressDiagonalSlideIn(float progress)
        {
            var dim = GetViewport().GetVisibleRect().Size;
            _rect.Size = new Vector2(progress * dim.Length(), 2 * dim.Length()); // doubling y to cover the whole screen
            // at progress = 0, the rect is hidden, at progress = 1 the whole screen is covered
            // _rect.Size = new Vector2(dim.Length() * progress, 2 * dim.Length()); // doubling y to cover the whole screen
            // _rect.GlobalPosition = dim + dim.Orthogonal();
            // _rect.Rotation = dim.AngleTo(Vector2.Right);
        }
    }
}
