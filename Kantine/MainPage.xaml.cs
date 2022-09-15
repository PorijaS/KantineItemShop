using Kantine.Model;
using Kantine.ViewModel;

namespace Kantine;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected void RegisterBTN(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PushAsync(new Register());
    }

	protected void LoginBTN(object sender, EventArgs e)
	{
        Shell.Current.Navigation.PushAsync(new Basket(new BasketViewModel()));
    }
}

