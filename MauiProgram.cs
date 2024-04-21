//using IT3048C_Final.Data;
//using IT3048C_Final.ViewModels;
//using IT3048C_Final.Views;
//using Microsoft.Extensions.Logging;

//namespace IT3048C_Final
//{
//    public static class MauiProgram
//    {
//        public static MauiApp CreateMauiApp()
//        {
//            var builder = MauiApp.CreateBuilder();
//            builder
//                .UseMauiApp<App>()
//                .ConfigureFonts(fonts =>
//                {
//                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
//                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
//                });

//            builder.Services.AddSingleton<AccountDB>();

//            builder.Services.AddTransient<AccountEntryView>();
//            builder.Services.AddTransient<AccountEntryViewModel>();

//#if DEBUG
//            builder.Logging.AddDebug();
//#endif

//            return builder.Build();
//        }
//    }
//}
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Extensions.DependencyInjection;
using IT3048C_Final.Data;
using IT3048C_Final.Models;
using IT3048C_Final.ViewModels;

namespace IT3048C_Final
{
    public class MauiProgram
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

            builder.Services.AddSingleton<AccountDB>();
            builder.Services.AddSingleton<AccountEntryViewModel>();

            return builder.Build();
        }
    }
}
