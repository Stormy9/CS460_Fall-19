namespace CS460_Hwk08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        //===============================================================================
        public Team()
        {
            Athletes = new HashSet<Athlete>();
            RaceResults = new HashSet<RaceResult>();
        }

        //-------------------------------------------------------------------------------
        public int TeamID { get; set; }

        //-------------------------------------------------------------------------------
        [Required, DisplayName("team")]
        [StringLength(72)]
        public string TeamName { get; set; }

        //-------------------------------------------------------------------------------
        public int CoachID { get; set; }

        //===============================================================================
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Athlete> Athletes { get; set; }

        public virtual Coach Coach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceResult> RaceResults { get; set; }

        //===============================================================================
    }
}
