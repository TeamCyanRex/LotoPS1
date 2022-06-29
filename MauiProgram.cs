using Microsoft.Extensions.Logging;

namespace LotoPS1;

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
			});
#if DEBUG
		builder.Services.AddLogging(configure =>
        {
            configure.AddDebug()
                .AddFilter("LotoPS1", LogLevel.Trace)
                .AddFilter("Microsoft", LogLevel.Warning);
        });
#endif

		return builder.Build();
	}

}
