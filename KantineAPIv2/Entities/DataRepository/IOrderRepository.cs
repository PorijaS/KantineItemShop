using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataRepository
{
    //Repository Interface where all the Requests Call functions are created, they are created here but they dont have their functionality added yet.
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order Get(long id);

        long Add(OrderModel entity);
        void Delete(Order entity);
    }
}
