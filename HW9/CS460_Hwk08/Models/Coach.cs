namespace CS460_Hwk08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        //===============================================================================
        public Coach()
        {
            Athletes = new HashSet<Athlete>();
            RaceResults = new HashSet<RaceResult>();
            Teams = new HashSet<Team>();
        }

        //-------------------------------------------------------------------------------
        public int CoachID { get; set; }

        //-------------------------------------------------------------------------------
        [Required, DisplayName("coach")]
        [StringLength(72)]
        public string CoachName { get; set; }

        //===============================================================================
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Athlete> Athletes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceResult> RaceResults { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Team> Teams { get; set; }

        //===============================================================================
    }
}
