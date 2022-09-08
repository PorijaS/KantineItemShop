using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataRepository
{
    //Repository Interface where all the Requests Call functions are created, they are created here but they dont have their functionality added yet.
    public interface IOrderLineRepository
    {
        IEnumerable<OrderLine> GetAll();
        OrderLine Get(long id);

        long Add(OrderLineModel entity);
        void Delete(OrderLine entity);
    }
}
