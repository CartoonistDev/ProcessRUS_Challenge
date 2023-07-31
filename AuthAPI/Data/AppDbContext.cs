using Microsoft.EntityFrameworkCore;
using AuthAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AuthAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //Adding values to the DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
