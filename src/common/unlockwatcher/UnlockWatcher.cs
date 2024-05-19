using System;
using Globals;
using Godot;
using Godot.Collections;

namespace UI
{
    public partial class UnlockWatcher : Node
    {
        [Export]
        private Unlocks _watchedUnlock;

        /// <summary>
        /// This is the node who's visibility gets changed when the unlock changes.
        /// </summary>
        [Export]
        private CanvasItem _targetNode;

        /// <summary>
        /// Inverts the show-hide logic
        /// </summary>
        [Export]
        private bool hideWhenUnlocked;

        private Eventbus _eventbus;
        private GameProgress _gameProgress;

        public override void _Ready()
        {
            _eventbus = GDAccessors.GetEventbus(this);
            _gameProgress = GDAccessors.GetGameProgress(this);

            UpdateVisibility();
            _eventbus.UnlocksChanged += OnUnlocksChanged;
        }

        private void OnUnlocksChanged(Dictionary<string, Variant> unlocks)
        {
            UpdateVisibility();
        }

        private void _on_pressed()
        {
            _eventbus.EmitStartClassicSingleWordGameClicked();
        }

        private void UpdateVisibility()
        {
            if (hideWhenUnlocked)
            {
                if (_gameProgress.HasUnlocked(_watchedUnlock))
                    _targetNode.Hide();
                else
                    _targetNode.Show();
            }
            else
            {
                if (_gameProgress.HasUnlocked(_watchedUnlock))
                    _targetNode.Show();
                else
                    _targetNode.Hide();
            }
        }
    }
}
