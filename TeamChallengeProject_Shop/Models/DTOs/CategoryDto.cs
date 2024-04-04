
namespace TeamChallengeProject_Shop.Models.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Delete_at { get; set; }
    }
}
