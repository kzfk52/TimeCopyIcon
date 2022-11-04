using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace TimeCopyIconMaui
{
    public static class MauiProgram
    {
        public static IServiceProvider Services { get; private set; }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();

            // config https://montemagno.com/dotnet-maui-appsettings-json-configuration/
            var assembly = Assembly.GetExecutingAssembly();
            //var assembly = typeof(App).GetTypeInfo().Assembly;
            var assemblyName = assembly.GetName().Name;
            using var stream = assembly.GetManifestResourceStream($"{assemblyName}.appsettings.json");

            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .AddJsonFile("appsettings.json", optional:true, reloadOnChange: true)
                        .Build();
            builder.Configuration.AddConfiguration(config);

            var app = builder.Build();
            Services = app.Services;

            return app;

        }
    }
}