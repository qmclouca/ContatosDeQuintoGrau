using CommunityToolkit.Maui;
using ContatosDeQuintoGrau.Plugins.DataStore.InMemory;
using Microsoft.Extensions.Logging;
using UseCases.PluginsInterface;


namespace ContatosDeQuintoGrau
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
            builder.UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            #region injeção de dependência
            builder.Services.AddSingleton<IContatosRepository, ContatosEmMemoriaRepository>();
      
            #endregion injeção de dependência

            return builder.Build();
        }
    }
}
