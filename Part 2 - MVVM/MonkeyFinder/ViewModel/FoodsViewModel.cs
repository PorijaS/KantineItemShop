using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class FoodsViewModel : BaseViewModel
{
    FoodService foodService;
    public ObservableCollection<Food> Foods { get; } = new ();

    public FoodsViewModel(FoodService foodService)
    {
        Title = "Food Finder";
        this.foodService = foodService;
    }

    [RelayCommand]
    async Task GetFoodsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var foods = await foodService.GetFoods();

            if (foods.Count != 0)
                foods.Clear();

            foreach (var food in foods)
                foods.Add(food);


        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", 
                $"Unable to get foods: {ex.Message}", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
