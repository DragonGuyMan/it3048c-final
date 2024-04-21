using IT3048C_Final.Data;
using IT3048C_Final.ViewModels;
using IT3048C_Final.Views;
using Microsoft.Extensions.Logging;

namespace IT3048C_Final
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<AccountDB>();

            builder.Services.AddSingleton<AccountListView>();
            builder.Services.AddTransient<AccountEntryView>();

            builder.Services.AddTransient<AccountEntryViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
