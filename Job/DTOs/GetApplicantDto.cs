using System.ComponentModel.DataAnnotations;

namespace JobAPIS.DTOs
{
    public class GetApplicantDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

    }
}
