using KantineAPIv2.DataModels;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KantineAPIv2.Controllers
{
    //API Controller for Food

    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        //Creating a _dataRepository reference
        private readonly IFoodRepository _dataRepository;

        //Creating Constructor
        public FoodController(IFoodRepository deviceRepository)
        {
            _dataRepository = deviceRepository;
        }

        // GET: api/Food
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Food> foods = _dataRepository.GetAll();
            return Ok(foods);
        }

        // GET: api/Food/1
        [HttpGet]
        [Route("{id}")]

        public IActionResult Get(long id)
        {
            Food food = _dataRepository.Get(id);
            if (food == null)
            {
                return NotFound("The food was not found");
            }
            return Ok(food);
        }

        // POST: api/Food   
        [HttpPost]
        public IActionResult Post([FromBody] FoodModel food)
        {
            if (food == null)
            {
                return BadRequest("Food is null");
            }

            var foodId = _dataRepository.Add(food);

            var result = _dataRepository.Get(foodId);
            return Ok(result);
        }

        // PUT: api/Food    
        [HttpPut]
        public IActionResult Put(long id, [FromBody] FoodModel food)
        {
            if (food == null)
            {
                return BadRequest("Food is null");
            }

            Food foodToUpdate = _dataRepository.Get(id);
            if (foodToUpdate == null)
            {
                return NotFound("The Food was not found ");
            }

            _dataRepository.Update(foodToUpdate, food);
            return Ok(food);
        }

        //Delete: api/Food/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            Food food = _dataRepository.Get(id);

            if (food == null)
            {
                return NotFound("The Food was not found");
            }
            _dataRepository.Delete(food);
            return Ok("The food was deleted");
        }
    }
}
