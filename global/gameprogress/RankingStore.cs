using System.Collections.Generic;
using System.Linq;
using Dtos;
using Godot;
using Godot.Collections;

namespace Globals
{
    internal sealed class RankingStore
    {
        private List<IRankingDto> _data = new List<IRankingDto> { };

        private const string _section = "Rankings";
        private const string _filepath = "user://rankings.cfg";
        private const int _maxPersistedRanks = 25;

        public List<IRankingDto> Rankings
        {
            get => _data;
        }

        internal void AddRank(IRankingDto newRank)
        {
            _data.Add(newRank);
            _data = (from rank in _data orderby rank.Score descending select rank)
                .Take(_maxPersistedRanks)
                .ToList();
        }

        internal void Save()
        {
            var config = new ConfigFile();

            foreach (var date in _data)
            {
                config.SetValue(_section, date.Id, date.ToDict());
            }
            var err = config.Save(_filepath);
            if (err != Error.Ok)
            {
                // FIXME: sth went wrong. notify caller and eventually player?
            }
        }

        internal void Load()
        {
            Reset();

            var config = new ConfigFile();
            Error err = config.Load(_filepath);
            if (err != Error.Ok)
                return; // ignore if nonexistent or corrupted

            foreach (string section in config.GetSections())
            {
                switch (section)
                {
                    case _section:
                    {
                        var ids = config.GetSectionKeys(_section);
                        foreach (string id in ids)
                        {
                            var rankingDict = (Dictionary)config.GetValue(section, id);
                            var dto = RankingDto.FromDict(rankingDict);
                            _data.Add(dto);
                        }
                        break;
                    }
                }
            }
        }

        private void Reset()
        {
            _data = new List<IRankingDto> { };
        }
    }
}
