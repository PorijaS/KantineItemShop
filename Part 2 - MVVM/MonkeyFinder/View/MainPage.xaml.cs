namespace MonkeyFinder.View;

public partial class MainPage : ContentPage
{
	public MainPage(FoodsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}

