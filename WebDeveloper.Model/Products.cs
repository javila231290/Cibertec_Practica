using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDeveloper.Model
{
    public partial class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Product Name ")]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        [Required]
        [Display(Name = "Category Name ")]
        public int? CategoryID { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Unit Price ")]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
