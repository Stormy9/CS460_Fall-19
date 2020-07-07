namespace CS460_Final_Exam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RSVP")]
    public partial class RSVP
    {
        // is this supposed to look like this???
        //===============================================================================
        public int RsvpID { get; set; }

        //-------------------------------------------------------------------------------
        public DateTime TimeStamp { get; set; }

        //-------------------------------------------------------------------------------
        public int PersonID { get; set; }

        //-------------------------------------------------------------------------------
        public int EventID { get; set; }

        //-------------------------------------------------------------------------------
        public virtual Event Event { get; set; }

        //-------------------------------------------------------------------------------
        public virtual Person Person { get; set; }
        //===============================================================================
    }
}
