using System.ComponentModel.DataAnnotations;

namespace TeamChallengeProject_Shop.Models
{
    public class ProductCategory
    {
        [Key]
        [Required]
        public int ProductCategoryId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
