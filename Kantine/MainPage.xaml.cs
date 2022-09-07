namespace Kantine;

public partial class MainPage : ContentPage
{
	int count = 0;

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
        Shell.Current.Navigation.PushAsync(new Menu());
    }
}

