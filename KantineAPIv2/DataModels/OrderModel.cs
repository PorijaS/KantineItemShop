namespace KantineAPIv2.DataModels
{
    //Model class that has the properties we need in our calls, instead of calling the main entity we will use the model class instead.
    public class OrderModel
    {
        public long OrderLine { get; set; }
        public DateTime OrderDate { get; set; }
        public float Price { get; set; }
        public long OrderUserId { get; set; }
    }
}
