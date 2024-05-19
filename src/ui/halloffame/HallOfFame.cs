using System;
using Godot;

namespace UI
{
    public partial class HallOfFame : MarginContainer
    {
        private RankingTable _rankingTable;

        public override void _Ready()
        {
            // TODO continue here. Need to save the data somewhere, load it, and use it here. Also nice would be: max words, max combo, etc. After that, implement SwitchModeButton
            _rankingTable = GetNode<RankingTable>("%RankingTable");
            _rankingTable.AddRow("TypeScriptTeatime", 3521);
            _rankingTable.AddRow("31337", 1337);
            _rankingTable.AddRow("Unknown UsernameTM", 831001);
            _rankingTable.Redraw();
        }
    }
}
