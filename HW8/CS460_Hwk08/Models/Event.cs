namespace CS460_Hwk08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        //===============================================================================
        public Event()
        {
            RaceResults = new HashSet<RaceResult>();
        }

        //-------------------------------------------------------------------------------
        public int EventID { get; set; }

        //-------------------------------------------------------------------------------
        [Required, DisplayName("event")]
        [StringLength(30)]
        public string EventType { get; set; }

        //===============================================================================
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceResult> RaceResults { get; set; }

        //===============================================================================
    }
}
