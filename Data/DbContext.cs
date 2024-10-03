using Microsoft.EntityFrameworkCore;
using StepIntoHelp.Models;

namespace StepIntoHelp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<HelpRequest> HelpRequests { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Response> Responses { get; set; }
    }
}