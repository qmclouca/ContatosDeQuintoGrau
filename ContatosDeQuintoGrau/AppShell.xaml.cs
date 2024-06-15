using ContatosDeQuintoGrau.Views;

namespace ContatosDeQuintoGrau
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ContatosPage), typeof(ContatosPage));
            Routing.RegisterRoute(nameof(AdicionarContatosPage), typeof(AdicionarContatosPage));
            Routing.RegisterRoute(nameof(EditarContatosPage), typeof(EditarContatosPage));
            
        }
    }
}
