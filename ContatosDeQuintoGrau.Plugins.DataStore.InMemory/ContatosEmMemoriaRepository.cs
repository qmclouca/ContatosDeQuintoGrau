using ContatosDeQuintoGrau.Models;

namespace ContatosDeQuintoGrau.Plugins.DataStore.InMemory
{    
    public class ContatosEmMemoriaRepository
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
    }
}
