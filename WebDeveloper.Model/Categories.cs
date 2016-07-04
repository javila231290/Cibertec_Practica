using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDeveloper.Model
{
    public partial class Categories
    {

        public Categories()
        {
            Products = new HashSet<Products>();
        }

        [Key]
        [Required]
        [Display(Name = "Category ID: ")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(15)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Category Description")]
        public string Description { get; set; }

        //[Column(TypeName = "image")]
        [Display(Name = "Image")]
        public byte[] Picture { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(50)]
        public string PictureFileName { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(50)]
        public string PictureContentType { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
