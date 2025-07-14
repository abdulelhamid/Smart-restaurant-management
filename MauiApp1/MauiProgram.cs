using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using Radzen;
using Supabase;
namespace MauiApp1
{
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
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddBlazoredLocalStorage();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
            builder.Services.AddSingleton<FoodService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<RequestService>();
            builder.Services.AddScoped<Food1Service>();
            builder.Services.AddScoped<Food2Service>();
            return builder.Build();
        }
    }
}
#endif
