using KantineAPIv2.Context;
using KantineAPIv2.DataModels;
using KantineAPIv2.Entities.DataRepository;
using Microsoft.AspNetCore.Components.Forms;

namespace KantineAPIv2.Entities.DataManager
{
    //DataManager class that handles Request Call Functionality
    public class FoodManager : IFoodRepository
    {
        //Creating a db context
        readonly DatabaseContext _dbContext;

        //Adding a class constructor
        public FoodManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get Function that fetches all Foods and posts them to a list
        public IEnumerable<Food> GetAll()
        {
            return _dbContext.Foods.ToList();
        }

        //Get Function that takes a id and looks in the database for said id in the Food table
        public Food Get(long id)
        {
            return _dbContext.Foods.FirstOrDefault(e => e.FoodId == id);
        }

        //Add function that takes a FoodModel and adds it to the Food table
        public long Add(FoodModel food)
        {
            var foodEntity = new Food(food.FoodName, food.FoodDescription, food.FoodCategoryId, food.Price, food.ImagePath);
            _dbContext.Foods.Add(foodEntity);
            _dbContext.SaveChanges();

            return foodEntity.FoodId;
        }

        //Update function that takes a Food that you want to update and the updated Food
        public void Update(Food foodToUpdate, FoodModel updatedFood)
        {
            foodToUpdate.FoodName = updatedFood.FoodName;
            foodToUpdate.FoodDescription = updatedFood.FoodDescription;
            foodToUpdate.FoodCategoryId = updatedFood.FoodCategoryId; 
            _dbContext.SaveChanges();
        }

        //Delete function that deletes a single Food
        public void Delete(Food food)
        {
            _dbContext.Foods.Remove(food);
            _dbContext.SaveChanges();
        }
    }
}
