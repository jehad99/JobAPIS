namespace JobAPIS.DTOs
{
    public class GetJobDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? JobRequirements { get; set; }
    }
}
