using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KantineAPIv2.Entities
{
    //Entity Class, modelled after database table


    [Table("OrderLine")]
    public class OrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long OrderLineId { get; set; }
        public long FoodId { get; set; }
        public int Amount { get; set; }

        public OrderLine(long foodId, int amount)
        {
            FoodId = foodId;
            Amount = amount;
        }
    }
}
