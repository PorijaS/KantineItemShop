using System.Collections.Generic;
using System.Linq;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Context;
using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataManager
{

    public class OrderManager : IOrderRepository
    {
        readonly DatabaseContext _dbContext;

        public OrderManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order Get(long id)
        {
            return _dbContext.Orders.FirstOrDefault(e => e.OrderId == id);
        }

        public long Add(OrderModel order)
        {
            var orderEntity = new Order(order.OrderLine, order.OrderDate, order.Price, order.OrderUserId);
            _dbContext.Orders.Add(orderEntity);
            _dbContext.SaveChanges();

            return orderEntity.OrderId;
        }

        public void Delete(Order order)
        {
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }
    }
}
