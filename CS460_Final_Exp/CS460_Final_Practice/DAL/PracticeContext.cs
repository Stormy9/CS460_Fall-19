using CS460_Final_Practice.Models; 

namespace CS460_Final_Practice.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PracticeContext : DbContext
    {
        public PracticeContext()
            //: base("name=PracticeContext")

             : base("name=PracticeContext_Azure")
        {
        }

        public virtual DbSet<Astronaut> Astronauts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Crew> Crews { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Astronaut>()
                .HasMany(e => e.Crews)
                .WithRequired(e => e.Astronaut)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Astronauts)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mission>()
                .HasMany(e => e.Crews)
                .WithRequired(e => e.Mission)
                .WillCascadeOnDelete(false);
        }
    }
}
