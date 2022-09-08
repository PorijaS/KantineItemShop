namespace KantineAPIv2.DataModels
{
    //Model class that has the properties we need in our calls, instead of calling the main entity we will use the model class instead.

    public class FoodModel
    {
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }

        public float Price { get; set; }
        public long FoodCategoryId { get; set; }

        public string ImagePath { get; set; }
    }
}
