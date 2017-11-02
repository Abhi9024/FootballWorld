using FootballWorld.Business.Logic.Infrastructure;
using FootballWorld.DataLayer.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballWorld.Business.Logic.Extension
{
    public static class ChampionsLeagueClubs 
    {
        public static IEnumerable<Club> GetChampionsLeagueClubs(this IEnumerable<Club> source) =>
         source.Where(c => c.Ranking < GlobalConstants.MaximumChampionsLeagueRanking);
    }
}
