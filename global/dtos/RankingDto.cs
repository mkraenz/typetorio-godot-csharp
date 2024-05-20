using System;
using System.Globalization;
using Godot.Collections;

namespace Dtos
{
    internal interface IRankingDto
    {
        string Id { get; }
        string PlayerName { get; }
        int Score { get; }
        int MaxCombo { get; }
        int WordsCleared { get; }
        public DateTime CreatedAt { get; }

        Dictionary ToDict();
    }

    internal sealed class RankingDto : IRankingDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string PlayerName { get; set; }

        public int Score { get; set; }

        public int MaxCombo { get; set; }

        public int WordsCleared { get; set; }
        public DateTime CreatedAt { get; set; }

        internal static RankingDto FromDict(Dictionary dict)
        {
            var dto = new RankingDto()
            {
                Id = (string)dict["Id"],
                PlayerName = (string)dict["PlayerName"],
                Score = (int)dict["Score"],
                MaxCombo = (int)dict["MaxCombo"],
                WordsCleared = (int)dict["WordsCleared"],
                CreatedAt = DateTime.Parse((string)dict["CreatedAt"], CultureInfo.InvariantCulture),
            };
            return dto;
        }

        public Dictionary ToDict()
        {
            var dict = new Dictionary();
            dict.Add("Id", Id);
            dict.Add("PlayerName", PlayerName);
            dict.Add("Score", Score);
            dict.Add("MaxCombo", MaxCombo);
            dict.Add("WordsCleared", WordsCleared);
            dict.Add("CreatedAt", DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture));
            return dict;
        }
    }
}
