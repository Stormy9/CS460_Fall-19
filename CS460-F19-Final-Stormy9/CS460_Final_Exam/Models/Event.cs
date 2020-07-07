namespace CS460_Final_Exam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            RSVPs = new HashSet<RSVP>();
        }

        //===============================================================================
        public int EventID { get; set; }

        //-------------------------------------------------------------------------------
        [Required, DisplayName("Event Title")]
        [StringLength(50)]
        public string EventTitle { get; set; }

        //-------------------------------------------------------------------------------
        [Required, DisplayName("Event Date & Time")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, 
          //              DataFormatString = "{0:MM-dd-yyyy}")]

        public DateTime EventStart { get; set; }

        //------------------------------------------------------------
        // okay so this did not work after the fact     [=
        //[DisplayName("Event Time")]

        //[DataType(DataType.Time)]             
        //public TimeSpan EventTime { get; set; }

        //-------------------------------------------------------------------------------
        [Required, DisplayName("Event Duration")]
        public int EventDuration { get; set; }

        //-------------------------------------------------------------------------------
        [Required, DisplayName("Event Location")]
        [StringLength(50)]
        public string EventLocation { get; set; }

        //-------------------------------------------------------------------------------
        public int PersonID { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RSVP> RSVPs { get; set; }
        //===============================================================================
    }
}
