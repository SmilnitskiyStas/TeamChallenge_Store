using System.ComponentModel.DataAnnotations;

namespace TeamChallengeProject_Shop.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public bool PickUp { get; set; }
        [Required]
        public bool Delivery { get; set; }
        [Required]
        public DateTime Created_at { get; set; }
        public DateTime Delete_at { get; set; }

        public Store Store { get; set; }
        public List<ProductCategory> ProductCategory { get; set; }
    }
}
