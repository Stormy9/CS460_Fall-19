using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CS460_Hwk05.Models;   // note this


namespace CS460_Hwk05.DAL
{
    // class that gives us access to a DB
    public class HomeworkContext : DbContext
    {
        // which database to connect to? ==> (details in web.config)
        public HomeworkContext() : base("name=OurHomeworkDB")
        {
            // ADDED PER DR. MORSE'S POST ON SLACK (Sunday evening):
            //      disable code-first migrations.....  
            // the default initializer is `CreateDatabaseIfNotExists` --
            // this sets the strategy to use the first time only the DbContext is created
            //      (this had been empty, at first.....)

            Database.SetInitializer<HomeworkContext>(null);

            // so in other words..... if the table gets deleted, simply entering
            // something on the `create` page will *not* create a new table!
            //      it would have to be created here, first.....
            //   this is so we have full control over set-up of our database
        }

        //===============================================================================
        // access to our Homeworks table ==> from Dr. Morse video sunday:
        //   DbSet<Homework>  <== singular to match model
        //          Homeworks  <== matches db name (make that the db TABLE)
        //                  (so i had it correct it turns out!)
        public virtual DbSet<Homework> Homeworks { get; set; }
        //               matches model | matches db table

        //===============================================================================
        // per Dr. Morse (from Slack + officeHours) -- 
        //      this will *force* Entity Framework to always connect to/pick
        //           the correct table in the db!
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Homework>().ToTable("Homeworks");
            //                matches model          matches db table
        }
        //===============================================================================
    }
}