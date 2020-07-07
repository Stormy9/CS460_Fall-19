namespace CS460_Hwk08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Athlete
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Athlete()
        {
            RaceResults = new HashSet<RaceResult>();
        }

        //===============================================================================
        public int AthleteID { get; set; }

        //-------------------------------------------------------------------------------
        [Required, DisplayName("athlete")]
        [StringLength(72)]
        public string AthleteName { get; set; }

        //-------------------------------------------------------------------------------
        [Required, DisplayName("gender")]
        [StringLength(6)]
        public string Gender { get; set; }

        //-------------------------------------------------------------------------------
        public int CoachID { get; set; }

        //-------------------------------------------------------------------------------
        public int TeamID { get; set; }

        //-------------------------------------------------------------------------------
        [DisplayName("coach")]
        public virtual Coach Coach { get; set; }

        //-------------------------------------------------------------------------------
        [DisplayName("team")]
        public virtual Team Team { get; set; }

        //===============================================================================
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceResult> RaceResults { get; set; }

        //===============================================================================
    }
}
