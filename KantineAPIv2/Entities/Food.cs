using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KantineAPIv2.Entities
{
    //Entity Class, modelled after database table

    [Table("Food")]
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public float Price { get; set; }

        public string ImagePath { get; set; }
        [ForeignKey("FoodCategory")]
        public long FoodCategoryId { get; set; }
        
        public virtual FoodCategory FoodCategory { get; set; }

        public Food(string foodName, string foodDescription, long foodCategoryId, float price, string imagePath)
        {
            FoodName = foodName;
            FoodDescription = foodDescription;
            FoodCategoryId = foodCategoryId;
            Price = price;
            ImagePath = imagePath;
        }
    }
}
