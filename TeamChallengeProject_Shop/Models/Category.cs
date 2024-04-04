using System.ComponentModel.DataAnnotations;

namespace TeamChallengeProject_Shop.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public int ParentId { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Delete_at { get; set; }
        public Product Product { get; set; }
    }
}
