using Globals;
using Godot;
using System;

namespace UI
{

	public partial class BlockClickspam : Node
	{
		[Export] private Button _target;
		private SceneTransition _sceneTransition;

		public override void _Ready()
		{
			_sceneTransition = GDAccessors.GetSceneTransition(this);
			_target.Pressed += OnTargetPressed;
			_sceneTransition.AnimationFinished += OnSceneTransitionFinished;
		}

		private void OnSceneTransitionFinished(string animationName)
		{
			_target.Disabled = false;
		}

		private void OnTargetPressed()
		{
			_target.Disabled = true;
		}

		private void _on_tree_exiting()
		{
			_sceneTransition.AnimationFinished -= OnSceneTransitionFinished;
			_target.Pressed -= OnTargetPressed;
		}
	}

}