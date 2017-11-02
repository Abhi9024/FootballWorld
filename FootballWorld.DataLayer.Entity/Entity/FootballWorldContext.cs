using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorld.DataLayer.Entity.Entity
{
    public class FootballWorldContext : DbContext
    {
        public FootballWorldContext(DbContextOptions<FootballWorldContext> options) :base(options)
        {

        }
        public DbSet<Club> Club { get; set; }
        public DbSet<League> League { get; set; }

        //protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=FootballWorld;Integrated Security=true;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(entry => 
            {
                entry.Property(e => e.ClubName).HasColumnType("varchar(100)");
                entry.Property(e => e.ClubDescription).HasColumnType("varchar(max)");
                entry.Property(e => e.ClubNetWorth).HasColumnType("money");
                entry.Property(e => e.Country).HasColumnType("varchar(100)");
                entry.Property(e => e.State).HasColumnType("varchar(100)");
                entry.Property(e => e.FoundedDate).HasColumnType("date");
                entry.HasOne(e => e.League)
                     .WithMany(e => e.Club)
                     .HasForeignKey(e => e.LeagueId)
                     .HasConstraintName("FK_Club_League");
            });

            modelBuilder.Entity<League>(entity => 
            {

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LeagueName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });
        }
    }
}
