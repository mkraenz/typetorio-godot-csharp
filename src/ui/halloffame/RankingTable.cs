using System;
using System.Collections.Generic;
using System.Linq;
using Dtos;
using Globals;
using Godot;

namespace UI
{
    public partial class RankingTable : VBoxContainer
    {
        [Export]
        private PackedScene _RankingRowScene;

        internal List<IRankingDto> Rankings { private get; set; }

        public void Redraw()
        {
            GDHelpers.QueueFreeAllChildren(this);

            var sortedRankings = (
                from rank in Rankings
                orderby rank.Score descending
                select rank
            ).ToArray();

            for (int rank = 1; rank <= sortedRankings.Length; rank++)
            {
                if (rank > 1)
                {
                    var divider = new HSeparator();
                    AddChild(divider);
                }
                var dto = sortedRankings[rank - 1];
                RankingRow row = _RankingRowScene.Instantiate<RankingRow>();
                row.Rank = rank;
                row.Username = dto.PlayerName;
                row.Score = dto.Score;
                AddChild(row);
            }
        }
    }
}
