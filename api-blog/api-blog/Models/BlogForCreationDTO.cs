using System.ComponentModel.DataAnnotations;

namespace api_blog.Models
{
    public class BlogForCreationDTO
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Body { get; set; }

        [Required]
        public int CreatedBy { get; set; }
    }
}
