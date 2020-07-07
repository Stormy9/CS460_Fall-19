namespace CS460_Final_Practice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mission")]
    public partial class Mission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mission()
        {
            Crews = new HashSet<Crew>();
        }


        public int MissionID { get; set; }


        [Required, DisplayName("Designation")]
        [StringLength(50)]
        public string Designation { get; set; }


        [Required, DisplayName("Description")]
        [StringLength(50)]
        public string Description { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Crew> Crews { get; set; }
    }
}
