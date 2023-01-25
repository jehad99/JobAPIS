using Microsoft.EntityFrameworkCore;

namespace JobAPIS.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Work> Jobs { get; set; }
    }
}
