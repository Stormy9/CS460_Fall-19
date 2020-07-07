namespace CS460_Hwk08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        //===============================================================================
        public Location()
        {
            RaceResults = new HashSet<RaceResult>();
        }

        //-------------------------------------------------------------------------------
        public int LocationID { get; set; }

        //-------------------------------------------------------------------------------
        [Required, DisplayName("location")]
        [StringLength(72)]
        public string LocationName { get; set; }

        //===============================================================================
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceResult> RaceResults { get; set; }

        //===============================================================================
    }
}
