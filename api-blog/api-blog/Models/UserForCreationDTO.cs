using System.ComponentModel.DataAnnotations;

namespace api_blog.Models
{
    public class UserForCreationDTO
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public int CreatedBy { get; set; }
    }
}
