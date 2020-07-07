using CS460_Hwk08.Models;       // is this the 'using' we add?

namespace CS460_Hwk08.DAL       // and this the 'namespace change' we make?
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TrackContext : DbContext
    {
        public TrackContext()
            : base("name=TrackContext")
        {
        }

        //===============================================================================
        public virtual DbSet<Athlete> Athletes { get; set; }

        //--------------------------------------------------------------------------------
        public virtual DbSet<Coach> Coaches { get; set; }
        
        //-------------------------------------------------------------------------------
        public virtual DbSet<Event> Events { get; set; }
        
        //-------------------------------------------------------------------------------
        public virtual DbSet<Location> Locations { get; set; }
        
        //-------------------------------------------------------------------------------
        public virtual DbSet<RaceResult> RaceResults { get; set; }
        
        //-------------------------------------------------------------------------------
        public virtual DbSet<Team> Teams { get; set; }

        //-------------------------------------------------------------------------------

        //===============================================================================
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>()
                .HasMany(e => e.RaceResults)
                .WithRequired(e => e.Athlete)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.Athletes)
                .WithRequired(e => e.Coach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.RaceResults)
                .WithRequired(e => e.Coach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Coach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.RaceResults)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.RaceResults)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Athletes)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.RaceResults)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);
        }
    }
}
