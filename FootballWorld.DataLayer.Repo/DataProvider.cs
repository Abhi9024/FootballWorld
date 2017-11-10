using System;
using System.Collections.Generic;
using FootballWorld.DataLayer.Entity.Entity;
using System.Linq;
using FootballWorld.Business.Logic.Infrastructure;
using FootballWorld.Business.Logic.Models;
using Microsoft.EntityFrameworkCore;
using FootballWorld.Business.Logic.Extension;

namespace FootballWorld.DataLayer.Repo
{
    public class DataProvider : IDataProvider
    {
        private FootballWorldContext _context;

        public DataProvider(FootballWorldContext context)
        {
            _context = context;
        }

        public ClubsServiceModel AddOrUpdateClub(ClubsServiceModel club)
        {
            var leagueId = _context.League.Where(l => l.LeagueName == club.LeagueName).Select(l=>l.Id).FirstOrDefault();

            var clubEntity = new Club()
            {
                ClubName = club.ClubName,
                ClubDescription = club.ClubDescription,
                LeagueId = leagueId,
                LeagueTitles = club.LeagueTitles,
                EuropaLeagueTitles = club.EuropaLeagueTitles,
                ChampionsLeagueTitles = club.ChampionsLeagueTitles,
                ClubNetWorth = club.ClubNetWorth,
                Country = club.Country,
                Defensive = club.Defensive,
                FoundedDate = club.FoundedDate,
                Offensive = club.Offensive,
                Ranking = club.Ranking,
                State = club.State
            };

            _context.Club.Add(clubEntity);
            _context.SaveChanges();

            return club;
        }

        public List<ClubsServiceModel> GetChampionsLeagueClub()
        {
            var entities = _context.Club
                                    .Include(c => c.League)
                                    .GetChampionsLeagueClubs();
                                   
            var returnData = new List<ClubsServiceModel>();
            foreach (var entity in entities)
            {
                var club = new ClubsServiceModel()
                {
                    ClubName = entity.ClubName,
                    ClubDescription = entity.ClubDescription,
                    LeagueName = entity.League.LeagueName,
                    ChampionsLeagueTitles = entity.ChampionsLeagueTitles,
                    ClubNetWorth = entity.ClubNetWorth,
                    Country = entity.Country,
                    EuropaLeagueTitles = entity.EuropaLeagueTitles,
                    FoundedDate = entity.FoundedDate,
                    LeagueTitles = entity.LeagueTitles,
                    Ranking = entity.Ranking,
                    State = entity.State,
                    Defensive=entity.Defensive,
                    Offensive=entity.Offensive
                };
                returnData.Add(club);
            }
            return returnData;
        }

        public List<Club> GetLeagueClubs(string league)
        {
            throw new NotImplementedException();
        }
    }
}
