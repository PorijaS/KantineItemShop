using KantineAPIv2.DataModels;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KantineAPIv2.Controllers
{
    //API Controller for Order

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //Creating a _dataRepository reference
        private readonly IOrderRepository _orderRepository;

        //Creating Constructor
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/order

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Order> orders = _orderRepository.GetAll();
            return Ok(orders);
        }

        // GET: api/order/1
        [HttpGet]
        [Route("{id}")]

        public IActionResult Get(long id)
        {
            Order order = _orderRepository.Get(id);
            if (order == null)
            {
                return NotFound("The Order was not found");
            }
            return Ok(order);
        }

        // POST: api/order
        [HttpPost]
        public IActionResult Post([FromBody] OrderModel order)
        {
            if (order == null)
            {
                return BadRequest("Order is null");
            }

            var orderId = _orderRepository.Add(order);

            var result = _orderRepository.Get(orderId);
            return Ok(result);
        }

        // PUT: api/order
        [HttpPut]
        //public IActionResult Put(long id, [FromBody] Order order)
        //{
        //    if (order == null)
        //    {
        //        return BadRequest("Order is null");
        //    }

        //    Order orderToUpdate = _dataRepository.Get(id);
        //    if (orderToUpdate == null)
        //    {
        //        return NotFound("The Order was not found ");
        //    }

        //    _dataRepository.Update(orderToUpdate, order);
        //    return Ok(order);
        //}

        //Delete: api/order/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            Order order = _orderRepository.Get(id);

            if (order == null)
            {
                return NotFound("The Order was not found");
            }
            _orderRepository.Delete(order);
            return Ok("The Order was deleted");
        }
    }
}
