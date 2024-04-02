using System.ComponentModel.DataAnnotations;

namespace TeamChallengeProject_Shop.Models.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool PickUp { get; set; }
        public bool Delivery { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Delete_at { get; set; }
    }
}
