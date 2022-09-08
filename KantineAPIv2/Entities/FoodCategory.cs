using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KantineAPIv2.Entities
{
    //Entity Class, modelled after database table

    [Table("FoodCategory")]
    public class FoodCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }

        public FoodCategory(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
