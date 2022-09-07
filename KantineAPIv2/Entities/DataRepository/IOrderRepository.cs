using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataRepository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order Get(long id);

        long Add(OrderModel entity);
        void Delete(Order entity);
    }
}
