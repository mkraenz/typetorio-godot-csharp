using System;
using Globals;
using Godot;

namespace UI
{
    public partial class HallOfFame : MarginContainer
    {
        private RankingTable _rankingTable;
        private GameProgress _gameProgress;

        public override void _Ready()
        {
            // TODO continue here. Also nice would be: max words, max combo, etc. After that, implement SwitchModeButton
            _rankingTable = GetNode<RankingTable>("%RankingTable");
            _gameProgress = GDAccessors.GetGameProgress(this);
            _rankingTable.Rankings = _gameProgress.Rankings;
            _rankingTable.Redraw();
        }

        private void _on_visibility_changed()
        {
            if (!IsInsideTree())
                return;
            _rankingTable.Rankings = _gameProgress.Rankings;
            _rankingTable.Redraw();
        }
    }
}
