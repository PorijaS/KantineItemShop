using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataRepository
{
    public interface IFoodCategoryRepository
    {
        IEnumerable<FoodCategory> GetAll();
        FoodCategory Get(long id);

        long Add(FoodCategoryModel entity);
        void Update(FoodCategory entityToUpdate, FoodCategoryModel updatedEntity);
        void Delete(FoodCategory entity);
    }
}
