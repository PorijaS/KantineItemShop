using KantineAPIv2.DataModels;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KantineAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _dataRepository;

        public OrderController(IOrderRepository deviceRepository)
        {
            _dataRepository = deviceRepository;
        }

        // GET: api/order

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Order> orders = _dataRepository.GetAll();
            return Ok(orders);
        }

        // GET: api/order/1
        [HttpGet]
        [Route("{id}")]

        public IActionResult Get(long id)
        {
            Order order = _dataRepository.Get(id);
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

            var orderId = _dataRepository.Add(order);

            var result = _dataRepository.Get(orderId);
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
            Order order = _dataRepository.Get(id);

            if (order == null)
            {
                return NotFound("The Order was not found");
            }
            _dataRepository.Delete(order);
            return Ok("The Order was deleted");
        }
    }
}
