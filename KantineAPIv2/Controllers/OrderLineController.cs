﻿using KantineAPIv2.DataModels;
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
    [Authorize]
    public class OrderLineController : ControllerBase
    {
        //Creating a _dataRepository reference
        private readonly IOrderLineRepository _foodCategoryRepository;

        //Creating Constructor
        public OrderLineController(IOrderLineRepository foodCategoryRepository)
        {
            _foodCategoryRepository = foodCategoryRepository;
        }

        // GET: api/orderLine
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<OrderLine> orderLines = _foodCategoryRepository.GetAll();
            return Ok(orderLines);
        }

        // GET: api/orderLine/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(long id)
        {
            OrderLine orderLine = _foodCategoryRepository.Get(id);
            if (orderLine == null)
            {
                return NotFound("The orderLine was not found");
            }
            return Ok(orderLine);
        }

        // POST: api/orderLine
        [HttpPost]
        public IActionResult Post([FromBody] OrderLineModel orderLine)
        {
            if (orderLine == null)
            {
                return BadRequest("OrderLine is null");
            }

            var orderLineId = _foodCategoryRepository.Add(orderLine);

            var result = _foodCategoryRepository.Get(orderLineId);
            return Ok(result);
        }

        //Delete: api/orderLine/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            OrderLine orderLine = _foodCategoryRepository.Get(id);

            if (orderLine == null)
            {
                return NotFound("The OrderLine was not found");
            }
            _foodCategoryRepository.Delete(orderLine);
            return Ok("The OrderLine was deleted");
        }
    }
}
