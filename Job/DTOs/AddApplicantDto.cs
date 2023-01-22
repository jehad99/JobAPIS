using System.ComponentModel.DataAnnotations;

namespace JobAPIS.DTOs
{
    public class AddApplicantDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
