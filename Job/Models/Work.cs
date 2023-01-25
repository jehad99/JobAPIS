using System.ComponentModel.DataAnnotations.Schema;

namespace JobAPIS.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string JobRequirements { get; set; }
        public Career Career { get; set; }
        public List<Applicant> Applicants { get; set; } 
    }
}
    