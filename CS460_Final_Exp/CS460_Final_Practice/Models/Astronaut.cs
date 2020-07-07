namespace CS460_Final_Practice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Astronaut")]
    public partial class Astronaut
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Astronaut()
        {
            Crews = new HashSet<Crew>();
        }


        public int AstronautID { get; set; }


        [Required, DisplayName("Astronaut")]
        [StringLength(50)]
        public string AstronautName { get; set; }



        [Column(TypeName = "date")]     // gets rid of '12:00:00 AM' appendage
        [Required, DisplayName("Birth Date")]
        //
        // adding this to the data definition gives me a date-picker in the view
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }
        //
        // constraint in DB so birthdate can not be in future.....


        [Required, DisplayName("Country")]
        public int CountryID { get; set; }

        public virtual Country Country { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Crew> Crews { get; set; }
    }
}
