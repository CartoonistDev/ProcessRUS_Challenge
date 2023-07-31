using System.ComponentModel.DataAnnotations;

namespace FruitsAPI.Models
{
    public class FavoriteFruits
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FruitName { get; set; }
        public string FruitColor { get; set; }
    }
}
