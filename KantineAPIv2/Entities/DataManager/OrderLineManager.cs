using System.Collections.Generic;
using System.Linq;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Context;
using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataManager
{
    //DataManager class that handles Request Call Functionality

    public class OrderLineManager : IOrderLineRepository
    {
        //Creating a db context
        readonly DatabaseContext _dbContext;

        //Adding a class constructor
        public OrderLineManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get Function that fetches all OrderLines and posts them to a list
        public IEnumerable<OrderLine> GetAll()
        {
            return _dbContext.OrderLines.ToList();
        }

        //Get Function that takes a id and looks in the database for said id in the OrderLine table
        public OrderLine Get(long id)
        {
            return _dbContext.OrderLines.FirstOrDefault(e => e.OrderLineId == id);
        }

        //Add function that takes a OrderLineModel and adds it to the OrderLine table
        public long Add(OrderLineModel orderLine)
        {
            var orderLineEntity = new OrderLine(orderLine.FoodId, orderLine.Amount, orderLine.OrderId);
            _dbContext.OrderLines.Add(orderLineEntity);
            _dbContext.SaveChanges();

            return orderLineEntity.OrderLineId;
        }

        //Delete function that deletes a single OrderLine
        public void Delete(OrderLine orderLine)
        {
            _dbContext.OrderLines.Remove(orderLine);
            _dbContext.SaveChanges();
        }
    }
}
