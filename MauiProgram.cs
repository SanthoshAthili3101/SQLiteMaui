using Microsoft.Extensions.Logging;
using SQLiteMaui.Data;

namespace SQLiteMaui
{
    public static class MauiProgram
    {
        public static string localFolderPath = "";
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            string folderName = "Internal-Storage";
            string localAppDataPath = AppDomain.CurrentDomain.BaseDirectory;
            localFolderPath = Path.Combine(localAppDataPath, folderName);
            if (!Directory.Exists(localFolderPath))
            {
                Directory.CreateDirectory(localFolderPath);
            }
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
		    builder.Logging.AddDebug(); 
            builder.Services.AddSingleton<DatabaseContext>();

            return builder.Build();
        }
    }
}