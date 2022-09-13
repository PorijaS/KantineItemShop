using Kantine.Views;

namespace Kantine.Templates;

public partial class VMItemTemplate : ContentView
{
	public VMItemTemplate()
	{
		InitializeComponent();
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await App.Current.MainPage.Navigation.PushModalAsync(new PopupPageVM());
	}
}