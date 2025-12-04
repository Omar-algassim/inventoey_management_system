using Microsoft.Extensions.Logging;
using Inventoey_Management.Database;
using SQLite;
using Inventoey_Management.Models;

namespace Inventoey_Management
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

            builder.Services.AddSingleton<SQLiteAsyncConnection>(s =>
            {
                var connection = new SQLiteAsyncConnection(
                    Constants.DatabasePath,
                    Constants.Flags);

                // Create all tables
                connection.CreateTableAsync<Admin>().Wait();
                connection.CreateTableAsync<Component>().Wait();
                connection.CreateTableAsync<Inventory>().Wait();
                connection.CreateTableAsync<Technician>().Wait();
                connection.CreateTableAsync<Client>().Wait();
                connection.CreateTableAsync<Request>().Wait();

                return connection;
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
