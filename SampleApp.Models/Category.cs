using System.ComponentModel.DataAnnotations;

namespace SampleApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Display order is required")]
        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }
    }
}
