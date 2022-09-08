using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataRepository
{
    //Repository Interface where all the Requests Call functions are created, they are created here but they dont have their functionality added yet.

    public interface IFoodRepository
    {
        IEnumerable<Food> GetAll();
        Food Get(long id);

        long Add(FoodModel entity);
        void Update(Food entityToUpdate, FoodModel updatedEntity);
        void Delete(Food entity);
    }
}
