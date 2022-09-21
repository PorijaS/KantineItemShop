namespace MonkeyFinder.Model;

public class Food
{
    public int foodId { get; set; }
    public string foodName { get; set; }
    public string foodDescription { get; set; }
    public int price { get; set; }
    public string imagePath { get; set; }
    public int foodCategoryId { get; set; }
}