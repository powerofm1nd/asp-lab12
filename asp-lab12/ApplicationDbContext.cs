using asp_lab12.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_lab12
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}