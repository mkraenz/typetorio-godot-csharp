using System;
using Globals;
using Godot;

namespace UI
{
    public partial class UnlocksView : VBoxContainer
    {
        private GameProgress _gameProgress;

        public override void _Ready()
        {
            _gameProgress = GDAccessors.GetGameProgress(this);
            // not using the UnlockWatcher because this component unlocks the shop feature on ready, meaning the unlockwatcher's listener for unlock changes would trigger and immediately hide the component.
            if (_gameProgress.HasUnlocked(Unlocks.Shop))
                Show();
            else
                Hide();
        }

        private void _on_back_to_main_menu_button_pressed()
        {
            Hide(); // from here on out, this component will never be shown again (unless you reset your unlocks)
        }

        public void UnlockShop()
        {
            if (!_gameProgress.HasUnlocked(Unlocks.Shop))
            {
                // not using the UnlockWatcher because this component unlocks the shop feature on ready, meaning the unlockwatcher's listener for unlock changes would trigger and immediately hide the component.
                _gameProgress.UnlockFeature(Unlocks.Shop);
                Show();
            }
            else
                Hide();
        }
    }
}
