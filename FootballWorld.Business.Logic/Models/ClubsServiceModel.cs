using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorld.Business.Logic.Models
{
    public class ClubsServiceModel
    {
        public string ClubName { get; set; }
        public string ClubDescription { get; set; }
        public string LeagueName { get; set; }
        public DateTime? FoundedDate { get; set; }
        public int? Ranking { get; set; }
        public int? LeagueTitles { get; set; }
        public int? ChampionsLeagueTitles { get; set; }
        public int? EuropaLeagueTitles { get; set; }
        public decimal? ClubNetWorth { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
