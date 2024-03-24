using System.ComponentModel.DataAnnotations;

namespace TeamChallengeProject_Shop.Models
{
    public class Image
    {
        [Required]
        [Key]
        public int ImageId { get; set; }
        [Required]
        public string UrlImage { get; set; }
    }
}
