namespace Kantine;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}

	protected void LoginBTN(object sender, EventArgs e)
	{
        Shell.Current.Navigation.PushAsync(new MainPage());
    }
}