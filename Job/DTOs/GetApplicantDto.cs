using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace JobAPIS.DTOs
{
    public class GetApplicantDto
    {
        public int Id { get; set; }
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
