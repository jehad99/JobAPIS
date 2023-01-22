using System.ComponentModel.DataAnnotations;

namespace JobAPIS.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Work? Job { get; set; }
    }
}
