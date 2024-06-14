using ContatosDeQuintoGrau.CoreBusiness;

namespace UseCases.PluginsInterface
{
    public interface IContatosRepository
    {
        Task AdicionarContato(Contato contato);
        Task<List<Contato>> RecuperarTodosContatos();
        Task RemoverContato(Contato contato);
    }
}
