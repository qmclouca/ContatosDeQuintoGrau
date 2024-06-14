using ContatosDeQuintoGrau.CoreBusiness;
using UseCases.Intefaces;
using UseCases.PluginsInterface;

namespace UseCases
{
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IContatosRepository _contatosRepository;

        public AddContactUseCase(IContatosRepository contatosRepository)
        {
            _contatosRepository = contatosRepository;
        }
        public async Task ExecuteAsync(Contato contato)
        {
            await _contatosRepository.AdicionarContato(contato);
        }
    }
}
