using ContatosDeQuintoGrau.CoreBusiness;
using UseCases.PluginsInterface;
using Contato = ContatosDeQuintoGrau.CoreBusiness.Contato;
namespace ContatosDeQuintoGrau.Plugins.DataStore.InMemory
{    
    public class ContatosEmMemoriaRepository : IContatosRepository
    {
        public static List<Contato> _contatos;

        public ContatosEmMemoriaRepository()
        {
            _contatos = new List<Contato>()
            {
                new Contato("Fulano de Tal1", "fulano1@teste.com","1111-11111","endereço fulano1"),
                new Contato("Fulano de Tal2", "fulano2@teste.com","2222-22222","endereço fulano2"),
                new Contato("Fulano de Tal3", "fulano3@teste.com","3333-33333","endereço fulano3"),
                new Contato("Fulano de Tal4", "fulano4@teste.com","4444-44444","endereço fulano4"),
                new Contato("Fulano de Tal5", "fulano5@teste.com","5555-55555","endereço fulano5")
            };
        }

        public Task AdicionarContato(Contato contato)
        {
            if (_contatos == null)
                _contatos = new List<Contato>();
            _contatos.Add(contato);
            return Task.CompletedTask;
        }

        public Task<List<Contato>> RecuperarTodosContatos()
        {
            return Task.FromResult(_contatos);          
        }

        public Task RemoverContato(Contato contato)
        {
            _contatos.Remove(contato);
            return Task.CompletedTask;
        }

        public Task AtualizarContato(Contato contato)
        {
            var contatoAtualizar = _contatos.FirstOrDefault(c => c.Id == contato.Id);
            if (contatoAtualizar != null)
            {
                contatoAtualizar.Name = contato.Name;
                contatoAtualizar.Email = contato.Email;
                contatoAtualizar.Phone = contato.Phone;
                contatoAtualizar.Address = contato.Address;
            }
            return Task.CompletedTask;
        }

        public Task<Contato> GetContactByIdAsync(Guid contactId)
        {
            var contact = _contatos.FirstOrDefault(c => c.Id.Equals(contactId));
            return  Task.FromResult(contact) ;
        }

        public Task<List<Contato>> SearchContacts(string filterText)
        {
            if (string.IsNullOrEmpty(filterText))
                return Task.FromResult(_contatos);

            IEnumerable<Contato> contatosByName = _contatos.Where(c => !string.IsNullOrWhiteSpace(c.Name) && c.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase));
            IEnumerable<Contato> contatosByEmail = _contatos.Where(c => !string.IsNullOrWhiteSpace(c.Email) && c.Email.Contains(filterText, StringComparison.OrdinalIgnoreCase));
            IEnumerable<Contato> contatosByPhone = _contatos.Where(c => !string.IsNullOrWhiteSpace(c.Phone) && c.Phone.Contains(filterText, StringComparison.OrdinalIgnoreCase));
            IEnumerable<Contato> contatosByAddress = _contatos.Where(c => !string.IsNullOrWhiteSpace(c.Address) && c.Address.Contains(filterText, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(contatosByName.Union(contatosByEmail).Union(contatosByPhone).Union(contatosByAddress).ToList());
        }

        public Task UpdateContact(Contato contato)
        {
            var contatoAtualizar = _contatos.FirstOrDefault(c => c.Id == contato.Id);
            if (contatoAtualizar != null)
            {
                contatoAtualizar.Name = contato.Name;
                contatoAtualizar.Email = contato.Email;
                contatoAtualizar.Phone = contato.Phone;
                contatoAtualizar.Address = contato.Address;
            }
            return Task.CompletedTask;
        }
    }
}
