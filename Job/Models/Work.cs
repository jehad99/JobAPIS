namespace JobAPIS.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frontend Developer";
        public string Description { get; set; } = "UI developer";
        public string JobRequirements { get; set; } = "2years exp, skills:html-css-js";
        public Career? Career { get; set; }
        public List<Applicant>? Applicants { get; set; } 
    }
}
