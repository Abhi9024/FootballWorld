using FootballWorld.Business.Logic.Models;
using FootballWorld.DataLayer.Entity.Entity;
using System.Collections.Generic;

namespace FootballWorld.DataLayer.Repo
{
    public interface IDataProvider
    {
        List<Club> GetLeagueClubs(string league);
        List<ClubsServiceModel> GetChampionsLeagueClub();
    }
}