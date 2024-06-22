using CommunityToolkit.Maui;
using ContatosDeQuintoGrau.Plugins.DataStore.InMemory;
using ContatosDeQuintoGrau.Views;
using Microsoft.Extensions.Logging;
using UseCases;
using UseCases.Intefaces;
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
            builder.Services.AddSingleton<IViewContactUseCase, ViewContactUseCase>();
            builder.Services.AddSingleton<IAddContactUseCase, AddContactUseCase>();
            builder.Services.AddSingleton<IUpdateContactUseCase, UpdateContactUseCase>();
            builder.Services.AddSingleton<IDeleteContactUseCase, DeleteContactUseCase>();
            #endregion injeção de dependência

            #region registro de rotas de navegação
            builder.Services.AddSingleton<ContatosPage>();
            builder.Services.AddSingleton<EditarContatosPage>();
            builder.Services.AddSingleton<AdicionarContatosPage>();
            #endregion registro de rotas de navegação

            return builder.Build();
        }
    }
}
