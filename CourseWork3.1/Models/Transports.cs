namespace CourseWork3._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transports
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transports()
        {
            Tour_point = new HashSet<Tour_point>();
        }

        [Key]
        public int Transport_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour_point> Tour_point { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
