using Microsoft.EntityFrameworkCore;
using JobTrack.Server.Models.Entities;

namespace JobTrack.Server.Data
{
    public class JobTrackDbContext: DbContext
    {
        public JobTrackDbContext(DbContextOptions options): base(options) 
        {
                
        }

        public DbSet<Application> Applications { get; set; }
    }
}
