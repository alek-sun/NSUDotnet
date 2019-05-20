using Microsoft.EntityFrameworkCore;

namespace Task4Web.Models
{
    public class EffectiveWorkerContext : DbContext
    {
        public EffectiveWorkerContext (DbContextOptions<EffectiveWorkerContext> options)
            : base(options)
        {
        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
    }
}
