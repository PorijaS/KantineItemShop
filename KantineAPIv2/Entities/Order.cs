using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KantineAPIv2.Entities
{

    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OrderId { get; set; }
        public long OrderLine { get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderPrice { get; set; }

        [ForeignKey("User")]
        public long OrderUserId { get; set; }

        public virtual User User { get; set; }

        public Order(long orderLine, DateTime orderDate, float orderPrice, long orderUserId)
        {
            OrderLine = orderLine;
            OrderDate = orderDate;
            OrderPrice = orderPrice;
            OrderUserId = orderUserId;
        }
    }
}
