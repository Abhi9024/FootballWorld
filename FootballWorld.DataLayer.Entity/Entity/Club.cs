using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorld.DataLayer.Entity.Entity
{
    public class Club
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string ClubDescription { get; set; }
        public int? LeagueId { get; set; }
        public DateTime? FoundedDate { get; set; }
        public int? Ranking { get; set; }
        public int? LeagueTitles { get; set; }
        public int? ChampionsLeagueTitles { get; set; }
        public int? EuropaLeagueTitles { get; set; }
        public decimal? ClubNetWorth { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual League League { get; set; }
    }
}
