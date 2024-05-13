using System;
using Godot;

namespace Globals
{
    public partial class SceneTransition : CanvasLayer
    {
        [Signal]
        public delegate void AnimationFinishedEventHandler(string animationName);
        private AnimationPlayer _anims;

        public override void _Ready()
        {
            base._Ready();
            _anims = GetNode<AnimationPlayer>("AnimationPlayer");
        }

        public void FadeInOut()
        {
            _anims.Play("fade_in_out");
        }

        public void FadeOut()
        {
            _anims.Play("fade_in");
        }


        public void FadeIn()
        {
            _anims.Play("fade_in", -1, -1, true);
        }


        private void _on_animation_player_animation_finished(string animationName)
        {
            EmitSignal(SignalName.AnimationFinished, animationName);
        }
    }
}
