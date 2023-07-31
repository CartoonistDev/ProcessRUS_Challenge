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

        public DbSet<FavoriteFruits> FavoriteFruits { get; set; }

        //Adding values to the DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FavoriteFruits>().HasData(new FavoriteFruits
            {
                Id = 1,
                FruitColor = "Orange",
                FruitName = "Orange"
            });

            modelBuilder.Entity<FavoriteFruits>().HasData(new FavoriteFruits
            {
                Id = 2,
                FruitColor = "Green",
                FruitName = "PawPaw"
            });

            modelBuilder.Entity<FavoriteFruits>().HasData(new FavoriteFruits
            {
                Id = 3,
                FruitColor = "Red",
                FruitName = "Strawberry"
            });

            modelBuilder.Entity<FavoriteFruits>().HasData(new FavoriteFruits
            {
                Id = 4,
                FruitColor = "Green",
                FruitName = "Mango"
            });

            modelBuilder.Entity<FavoriteFruits>().HasData(new FavoriteFruits
            {
                Id = 5,
                FruitColor = "Yellow",
                FruitName = "Pineapple"
            });

            modelBuilder.Entity<FavoriteFruits>().HasData(new FavoriteFruits
            {
                Id = 6,
                FruitColor = "Green",
                FruitName = "Apple"
            });

            modelBuilder.Entity<FavoriteFruits>().HasData(new FavoriteFruits
            {
                Id = 7,
                FruitColor = "Green",
                FruitName = "Watermelon"
            });

            modelBuilder.Entity<FavoriteFruits>().HasData(new FavoriteFruits
            {
                Id = 8,
                FruitColor = "Yellow",
                FruitName = "Banana"
            });

            modelBuilder.Entity<FavoriteFruits>().HasData(new FavoriteFruits
            {
                Id = 9,
                FruitColor = "Green",
                FruitName = "Avocado"
            });

        }


    }
}
