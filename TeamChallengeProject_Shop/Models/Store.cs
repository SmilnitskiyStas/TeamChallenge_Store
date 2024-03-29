using System.ComponentModel.DataAnnotations;

namespace TeamChallengeProject_Shop.Models
{
    public class Store
    {
        [Key]
        [Required]
        public int StoreId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Delete_at { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
