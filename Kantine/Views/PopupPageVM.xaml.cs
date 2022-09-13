using Kantine.Controls;

namespace Kantine.Views;

public partial class PopupPageVM : BasePopupPage
{
	public PopupPageVM()
	{
		InitializeComponent();
	}

	private async void TapGestureRecognizer_Tapped_NavigateToPopupPageVM(object sender, EventArgs e)
	{
		await App.Current.MainPage.Navigation.PushModalAsync(new PopupPageCandy());
	}

	private async void TapGestureRecognizer_Tapped_NavigateToNormalPage(object sender, EventArgs e)
	{
		await App.Current.MainPage.Navigation.PopModalAsync();
		await App.Current.MainPage.Navigation.PushAsync(new Profil());
	}
}