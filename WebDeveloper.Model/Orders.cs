using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDeveloper.Model
{

    public partial class Orders
    {
        [Key]
        public int OrderID { get; set; }

        //[StringLength(5)]
        //public string CustomerID { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public int? CustomerID { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        public int? EmployeeID { get; set; }

        [Required]
        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Freight")]
        public decimal? Freight { get; set; }

        [StringLength(40)]
        public string ShipName { get; set; }

        [StringLength(60)]
        public string ShipAddress { get; set; }

        [StringLength(15)]
        public string ShipCity { get; set; }

        [StringLength(15)]
        public string ShipRegion { get; set; }

        [StringLength(10)]
        public string ShipPostalCode { get; set; }

        [StringLength(15)]
        public string ShipCountry { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Employees Employees { get; set; }
    }
}
