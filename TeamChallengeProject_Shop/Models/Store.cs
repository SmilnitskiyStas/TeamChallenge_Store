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
        public string Create_at { get; set; }
        public string Delete_at { get; set; }
    }
}
