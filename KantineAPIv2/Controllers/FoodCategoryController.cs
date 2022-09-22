using KantineAPIv2.DataModels;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KantineAPIv2.Controllers
{
    //API Controller for FoodCategory

    [Route("api/[controller]")]
    [ApiController]
    public class FoodCategoryController : ControllerBase
    {
        //Creating a _dataRepository reference
        private readonly IFoodCategoryRepository _dataRepository;

        //Creating Constructor
        public FoodCategoryController(IFoodCategoryRepository deviceRepository)
        {
            _dataRepository = deviceRepository;
        }

        // GET: api/foodCategory
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<FoodCategory> foodCategories = _dataRepository.GetAll();
            return Ok(foodCategories);
        }

        // GET: api/foodCategory/1
        [HttpGet]
        [Route("{id}")]

        public IActionResult Get(long id)
        {
            FoodCategory foodCategory = _dataRepository.Get(id);
            if (foodCategory == null)
            {
                return NotFound("The FoodCategory was not found");
            }
            return Ok(foodCategory);
        }

        // POST: api/foodCategory
        [HttpPost]
        public IActionResult Post([FromBody] FoodCategoryModel foodCategory)
        {
            if (foodCategory == null)
            {
                return BadRequest("FoodCategory is null");
            }

            var foodcategoryId = _dataRepository.Add(foodCategory);

            var result = _dataRepository.Get(foodcategoryId);
            return Ok(result);
        }

        // PUT: api/foodCategory
        [HttpPut]
        public IActionResult Put(long id, [FromBody] FoodCategoryModel foodCategory)
        {
            if (foodCategory == null)
            {
                return BadRequest("FoodCategory is null");
            }

            FoodCategory foodCategoryToUpdate = _dataRepository.Get(id);
            if (foodCategoryToUpdate == null)
            {
                return NotFound("The FoodCategory was not found ");
            }

            _dataRepository.Update(foodCategoryToUpdate, foodCategory);
            return Ok(foodCategory);
        }

        //Delete: api/foodCategory/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            FoodCategory foodCategory = _dataRepository.Get(id);

            if (foodCategory == null)
            {
                return NotFound("The FoodCategory was not found");
            }
            _dataRepository.Delete(foodCategory);
            return Ok("The FoodCategory was deleted");
        }
    }
}
