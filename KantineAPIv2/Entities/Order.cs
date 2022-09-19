using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KantineAPIv2.Entities
{
    //Entity Class, modelled after database table

    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderPrice { get; set; }

        [ForeignKey("User")]
        public long OrderUserId { get; set; }

        public virtual User User { get; set; }

        public Order(DateTime orderDate, float orderPrice, long orderUserId)
        {
            OrderDate = orderDate;
            OrderPrice = orderPrice;
            OrderUserId = orderUserId;
        }
    }
}
