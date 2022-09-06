using System.Collections.Generic;
using System.Linq;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Context;
using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataManager
{
    public class FoodCategoryManager : IFoodCategoryRepository
    {
        readonly DatabaseContext _dbContext;

        public FoodCategoryManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<FoodCategory> GetAll()
        {
            return _dbContext.FoodCategories.ToList();
        }

        public FoodCategory Get(long id)
        {
            return _dbContext.FoodCategories.FirstOrDefault(e => e.CategoryId == id);
        }

        public long Add(FoodCategoryModel foodCategory)
        {
            var foodCategoryEntity = new FoodCategory(foodCategory.CategoryName);
            _dbContext.FoodCategories.Add(foodCategoryEntity);
            _dbContext.SaveChanges();

            return foodCategoryEntity.CategoryId;
        }

        public void Update(FoodCategory foodCategoryToUpdate, FoodCategoryModel foodCategoryUpdated)
        {
            foodCategoryToUpdate.CategoryName = foodCategoryUpdated.CategoryName;
            _dbContext.SaveChanges();
        }

        public void Delete(FoodCategory foodCategory)
        {
            _dbContext.FoodCategories.Remove(foodCategory);
            _dbContext.SaveChanges();
        }
    }
}
