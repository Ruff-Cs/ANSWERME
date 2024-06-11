using ANSWER_ME.ViewModels;
using ANSWER_ME.Views;
using Microsoft.Extensions.Logging;

namespace ANSWER_ME
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
                    fonts.AddFont("Alef-Regular.ttf", "Alef");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<HomeView>();
            builder.Services.AddSingleton<HomeViewModel>();

            builder.Services.AddSingleton<AchivementView>();
            builder.Services.AddSingleton<AchivementsViewModel>();

            builder.Services.AddSingleton<TriviaView>();
            builder.Services.AddSingleton<TriviaViewModel>();

            return builder.Build();
        }
    }
}