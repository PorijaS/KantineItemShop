using Kantine.ViewModel;

namespace Kantine;

public partial class Basket : ContentPage
{
    public Basket()
    {
    }

    public Basket(BasketViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}