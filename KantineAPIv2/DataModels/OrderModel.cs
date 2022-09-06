namespace KantineAPIv2.DataModels
{
    public class OrderModel
    {
        public long OrderLine { get; set; }
        public DateTime OrderDate { get; set; }
        public float Price { get; set; }
        public long OrderUserId { get; set; }
    }
}
