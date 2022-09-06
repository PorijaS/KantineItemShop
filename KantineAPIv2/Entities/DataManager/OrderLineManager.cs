using System.Collections.Generic;
using System.Linq;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Context;
using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataManager
{
    public class OrderLineManager : IOrderLineRepository
    {
        readonly DatabaseContext _dbContext;

        public OrderLineManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<OrderLine> GetAll()
        {
            return _dbContext.OrderLines.ToList();
        }

        public OrderLine Get(long id)
        {
            return _dbContext.OrderLines.FirstOrDefault(e => e.OrderLineId == id);
        }

        public long Add(OrderLineModel orderLine)
        {
            var orderLineEntity = new OrderLine(orderLine.FoodId, orderLine.Amount);
            _dbContext.OrderLines.Add(orderLineEntity);
            _dbContext.SaveChanges();

            return orderLineEntity.OrderLineId;
        }

        public void Delete(OrderLine orderLine)
        {
            _dbContext.OrderLines.Remove(orderLine);
            _dbContext.SaveChanges();
        }
    }
}
