namespace JobAPIS.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public string Email { get; set; } = "ex.gmail.com";
        public Work? Job { get; set; }
    }
}
