using AdminGastosApp.Services;
using AdminGastosApp.ViewModels;
using AdminGastosApp.Views;
using CommunityToolkit.Maui;
using Microcharts.Maui;
using Microsoft.Extensions.Logging;

namespace AdminGastosApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMicrocharts()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
			// 🔹 Registramos los servicios y ViewModels
			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<DatabaseService>(); // Servicio global (BD)
			builder.Services.AddSingleton<GastosViewModel>(); // VM compartido (MainPage)
			builder.Services.AddTransient<ResumenViewModel>(); // VM específico (ResumenPage)
			builder.Services.AddTransient<AgregarGastoViewModel>(); // VM específico (AgregarGastoPage)
			builder.Services.AddTransient<ResumenPage>(); // Página con VM inyectado
			builder.Services.AddTransient<AgregarGastoPage>(); // Página con VM inyectado
			builder.Services.AddTransient<AgregarCategoriaViewModel>();
			builder.Services.AddTransient<AgregarCategoriaPage>();

			return builder.Build();
        }
    }
}
