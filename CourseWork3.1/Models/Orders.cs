namespace CourseWork3._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        public Orders()
        {
        }

        public Orders(int clientId, int tourId, DateTime dateOfRegistration, int? employeeId)
        {
            Client_ID = clientId;
            Tour_ID = tourId;
            DateOfRegistration = dateOfRegistration;
            Employee_ID = employeeId;
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Client_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tour_ID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DateOfRegistration { get; set; }

        public int? Employee_ID { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Employees Employees { get; set; }

        public virtual Tours Tours { get; set; }
    }
}
