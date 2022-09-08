using System.Collections.Generic;
using System.Linq;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Context;
using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataManager
{
    //DataManager class that handles Request Call Functionality
    public class FoodCategoryManager : IFoodCategoryRepository
    {
        //Creating a db context
        readonly DatabaseContext _dbContext;

        //Adding a class constructor
        public FoodCategoryManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get Function that fetches all FoodCategories and posts them to a list
        public IEnumerable<FoodCategory> GetAll()
        {
            return _dbContext.FoodCategories.ToList();
        }

        //Get Function that takes a id and looks in the database for said id in the FoodCategory table
        public FoodCategory Get(long id)
        {
            return _dbContext.FoodCategories.FirstOrDefault(e => e.CategoryId == id);
        }

        //Add function that takes a FoodCategoryModel and adds it to the foodcategory table
        public long Add(FoodCategoryModel foodCategory)
        {
            var foodCategoryEntity = new FoodCategory(foodCategory.CategoryName);
            _dbContext.FoodCategories.Add(foodCategoryEntity);
            _dbContext.SaveChanges();

            return foodCategoryEntity.CategoryId;
        }

        //Update function that takes a FoodCategory that you want to update and the updated FoodCategory
        public void Update(FoodCategory foodCategoryToUpdate, FoodCategoryModel foodCategoryUpdated)
        {
            foodCategoryToUpdate.CategoryName = foodCategoryUpdated.CategoryName;
            _dbContext.SaveChanges();
        }

        //Delete function that deletes a single FoodCategory
        public void Delete(FoodCategory foodCategory)
        {
            _dbContext.FoodCategories.Remove(foodCategory);
            _dbContext.SaveChanges();
        }
    }
}
