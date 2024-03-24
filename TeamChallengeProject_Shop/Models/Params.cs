using System.ComponentModel.DataAnnotations;

namespace TeamChallengeProject_Shop.Models
{
    public class Params
    {
        [Key]
        [Required]
        public int ParamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Create_at { get; set; }
        public string Delete_at { get; set; }
    }
}
