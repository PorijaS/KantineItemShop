using System.Windows.Input;

namespace Kantine.Controls;

public partial class BasePopupPage : ContentPage
{
	public BasePopupPage()
	{
		InitializeComponent();
		this.BackgroundColor = Color.FromArgb("#80000000");
	}

	public static readonly BindableProperty PopContentProperty = BindableProperty.Create(
		propertyName: nameof(PopupContent),
		returnType: typeof(View),
		declaringType: typeof(BasePopupPage),
		defaultValue: null,
		defaultBindingMode: BindingMode.OneWay,
		propertyChanged: PopupContentPropertyChanged);

	private static void PopupContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var controls = (BasePopupPage)bindable;
		if (newValue != null)
			controls.ContentView.Content = (View)newValue;
	}

	public View PopupContent
	{
		get => (View)GetValue(PopContentProperty);
		set { SetValue(PopContentProperty, value); }
	}

	public ICommand PopModelCommand => new Command(async () =>
	{
		await App.Current.MainPage.Navigation.PopModalAsync();
	});
}