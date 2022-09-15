using Kantine.Model;
using Kantine.ViewModel;

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

	private void RegisterUser(object sender, EventArgs e)
	{
		User user = new User();

		user.Email = email.Text;
		user.Password = password.Text;
		user.RepeatPassword = rePass.Text;

		if (email == null || password == null || rePass == null)
		{
			DisplayAlert("Warning", "Please Input data in the fields","Ok");
			return;
		}

		if (password.Text != rePass.Text)
		{
			DisplayAlert("Warning","The Password is incorrect","Ok");
			return;
		}
	}
}