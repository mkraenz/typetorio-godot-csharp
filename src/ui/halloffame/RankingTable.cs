using System;
using System.Collections.Generic;
using System.Linq;
using Globals;
using Godot;

namespace UI
{
    public partial class RankingTable : VBoxContainer
    {
        [Export]
        private PackedScene _RankingRowScene;

        private Dictionary<string, int> _playerToScore = new Dictionary<string, int>();

        public void AddRow(string name, int score)
        {
            _playerToScore.Add(name, score);
        }

        public void Clear()
        {
            _playerToScore = new Dictionary<string, int>();
            Redraw();
        }

        public void Redraw()
        {
            GDHelpers.QueueFreeAllChildren(this);

            var sortedPlayerToScore = (
                from rank in _playerToScore
                orderby rank.Value descending
                select rank
            ).ToArray();

            for (int rank = 1; rank <= sortedPlayerToScore.Length; rank++)
            {
                if (rank > 1)
                {
                    var divider = new HSeparator();
                    AddChild(divider);
                }
                var ps = sortedPlayerToScore[rank - 1];
                RankingRow row = _RankingRowScene.Instantiate<RankingRow>();
                row.Rank = rank;
                row.Username = ps.Key;
                row.Score = ps.Value;
                AddChild(row);
            }
        }
    }
}
