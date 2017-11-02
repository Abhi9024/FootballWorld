using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorld.DataLayer.Entity.Entity
{
    public class League
    {
        public League()
        {
            Club = new HashSet<Club>();
        }

        public int Id { get; set; }
        public string LeagueName { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Club> Club { get; set; }
    }
}
