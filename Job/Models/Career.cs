namespace JobAPIS.Models
{
    public class Career
    {
        public int Id { get; set; }
        public string CareerName { get; set; }
        public List<Work> Jobs { get; set; }
    }
}
