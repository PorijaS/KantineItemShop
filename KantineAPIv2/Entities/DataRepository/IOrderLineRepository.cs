namespace KantineAPIv2.Entities.DataRepository
{
    public interface IOrderLineRepository
    {
        IEnumerable<OrderLine> GetAll();
        OrderLine Get(long id);

        long Add(OrderLineModel entity);
        void Delete(OrderLine entity);
    }
}
