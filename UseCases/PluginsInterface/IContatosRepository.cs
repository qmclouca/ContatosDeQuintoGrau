using ContatosDeQuintoGrau.CoreBusiness;

namespace UseCases.PluginsInterface
{
    public interface IContatosRepository
    {
        Task AdicionarContato(Contato contato);
        Task<List<Contato>> RecuperarTodosContatos();
        Task RemoverContato(Contato contato);
        Task AtualizarContato(Contato contato);
        Task<Contato> GetContactByIdAsync(Guid contactId);
        Task<List<Contato>> SearchContacts(string filterText);
    }
}
