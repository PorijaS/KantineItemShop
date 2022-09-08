using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataRepository
{
    //Repository Interface where all the Requests Call functions are created, they are created here but they dont have their functionality added yet.
    public interface IFoodCategoryRepository
    {
        IEnumerable<FoodCategory> GetAll();
        FoodCategory Get(long id);                                                                   

        long Add(FoodCategoryModel entity);
        void Update(FoodCategory entityToUpdate, FoodCategoryModel updatedEntity);
        void Delete(FoodCategory entity);
    }
}
