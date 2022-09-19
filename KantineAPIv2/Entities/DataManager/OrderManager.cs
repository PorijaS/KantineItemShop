using System.Collections.Generic;
using System.Linq;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Context;
using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataManager
{
    //DataManager class that handles Request Call Functionality

    public class OrderManager : IOrderRepository
    {
        //Creating a db context
        readonly DatabaseContext _dbContext;

        //Adding a class constructor
        public OrderManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get Function that fetches all Orders and posts them to a list
        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        //Get Function that takes a id and looks in the database for said id in the Order table
        public Order Get(long id)
        {
            return _dbContext.Orders.FirstOrDefault(e => e.OrderId == id);
        }

        //Add function that takes a OrderModel and adds it to the Order table
        public long Add(OrderModel order)
        {
            var orderEntity = new Order(order.OrderDate, order.Price, order.OrderUserId);
            _dbContext.Orders.Add(orderEntity);
            _dbContext.SaveChanges();

            return orderEntity.OrderId;
        }

        //Delete function that deletes a single Order
        public void Delete(Order order)
        {
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }
    }
}
