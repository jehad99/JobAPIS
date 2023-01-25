using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace JobAPIS.DTOs
{
    public class AddApplicantDto
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Range(11, 11, ErrorMessage = "The field Phone must be 11 numbers")]
        public string Phone { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int JobId { get; set; }

    }
}
