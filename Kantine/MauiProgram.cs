using Kantine.Templates;

namespace Kantine;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
                fonts.AddFont("Sitka.ttc", "Sitka");
            });


        builder.Services.AddTransient<Register>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<Menu>();
        builder.Services.AddTransient<VMItemTemplate>();
        builder.Services.AddTransient<CandyItemTemplate>();

        return builder.Build();
	}
}
