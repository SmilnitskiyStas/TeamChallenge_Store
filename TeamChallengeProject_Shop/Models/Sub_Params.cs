using System.ComponentModel.DataAnnotations;

namespace TeamChallengeProject_Shop.Models
{
    public class Sub_Params
    {
        [Key]
        [Required]
        public int SubParamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Create_at { get; set; }
        public string Delete_at { get; set; }
        public int ParamId { get; set; }
    }
}
