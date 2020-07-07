namespace CS460_Hwk08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RaceResult
    {
        public int RaceResultID { get; set; }

        //-------------------------------------------------------------------------------
        public int LocationID { get; set; }

        //-------------------------------------------------------------------------------
        [Column(TypeName = "date")]     // gets rid of '12:00:00 AM' appendage
        [Required, DisplayName("meet date")]

        // adding this to the data definition gives me a date-picker in the view
        [DataType(DataType.Date)]           
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        // it also formats things correctly for going into our db..... yay!

        public DateTime MeetDate { get; set; }

        //-------------------------------------------------------------------------------
        [Required, DisplayName("gender")]
        [StringLength(9)]
        public string Gender { get; set; }

        //-------------------------------------------------------------------------------
        [DisplayName("finish time")]
        public float FinishTime { get; set; }

        //-------------------------------------------------------------------------------
        public int AthleteID { get; set; }

        //-------------------------------------------------------------------------------
        public int CoachID { get; set; }

        //-------------------------------------------------------------------------------
        public int TeamID { get; set; }

        //-------------------------------------------------------------------------------
        public int EventID { get; set; }

        //-------------------------------------------------------------------------------
        [DisplayName("athlete")]
        public virtual Athlete Athlete { get; set; }

        //-------------------------------------------------------------------------------
        [DisplayName("coach")]
        public virtual Coach Coach { get; set; }

        //-------------------------------------------------------------------------------
        [DisplayName("event")]
        public virtual Event Event { get; set; }

        //-------------------------------------------------------------------------------
        [DisplayName("meet")]
        public virtual Location Location { get; set; }

        //-------------------------------------------------------------------------------
        [DisplayName("team")]
        public virtual Team Team { get; set; }

        //===============================================================================
    }
}
