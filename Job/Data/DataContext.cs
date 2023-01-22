using Microsoft.EntityFrameworkCore;

namespace JobAPIS.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Applicant> Applicants => Set<Applicant>();
        public DbSet<Career> Careers => Set<Career>();
        public DbSet<Work> Jobs => Set<Work>();
    }
}
