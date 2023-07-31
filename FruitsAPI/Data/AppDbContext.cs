using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FruitsAPI.Models;

namespace FruitsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

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
