using FakeStoreMaui.Data;
using FakeStoreMaui.Services;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components;
namespace FakeStoreMaui
{
    public static class MauiProgram
    {
        public class ErrorPage : ComponentBase
        {
            [Parameter]
            public string Message { get; set; }
        }
        public static MauiApp CreateMauiApp()
        {

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            
            builder.Services.AddMudServices();

            //---------INICIO-----------------
            builder.Services.AddSingleton<IProductoService, ProductoService>();
            builder.Services.AddScoped<IProductoService, ProductoService>();
            builder.Services.AddSingleton<ICategoriaService, CategoriaService>();
            builder.Services.AddScoped<ICategoriaService, CategoriaService>();

            //---------FIN--------------------
            


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}
