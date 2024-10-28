using System.ComponentModel.DataAnnotations;

namespace MVCshop.Models
{
    public class UserDetail
    {
        [Required]
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(35)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35)]
        public string LastName { get; set; }

        [Required,StringLength(50)]
        public string EmailId { get; set; }

        [Required,StringLength(15)]
        public string Password { get; set; }

        public bool isActive { get; set; } = true;
    }
}
