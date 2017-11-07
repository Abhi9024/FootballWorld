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
