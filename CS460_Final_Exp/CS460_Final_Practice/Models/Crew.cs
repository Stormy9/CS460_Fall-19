namespace CS460_Final_Practice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Crew")]
    public partial class Crew
    {
        public int CrewID { get; set; }

        [Required, DisplayName("Position")]
        [StringLength(50)]
        public string Position { get; set; }


        [Required, DisplayName("Astronaut")]
        public int AstronautID { get; set; }


        [Required, DisplayName("Mission")]
        public int MissionID { get; set; }


        public virtual Astronaut Astronaut { get; set; }

        public virtual Mission Mission { get; set; }
    }
}
