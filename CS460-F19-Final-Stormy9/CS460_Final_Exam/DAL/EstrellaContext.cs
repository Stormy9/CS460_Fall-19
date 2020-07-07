using CS460_Final_Exam.Models;      // 'using' .Models

namespace CS460_Final_Exam.DAL      // namespace from .Models to .DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EstrellaContext : DbContext
    {
        public EstrellaContext()
            : base("name=EstrellaContext_Azure")
        {
        }

        //===============================================================================
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<RSVP> RSVPs { get; set; }

        //===============================================================================
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasMany(e => e.RSVPs)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.RSVPs)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);
        }
    }
}
