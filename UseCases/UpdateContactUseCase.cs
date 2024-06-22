using ContatosDeQuintoGrau.CoreBusiness;
using UseCases.Intefaces;
using UseCases.PluginsInterface;

namespace UseCases
{
    public class UpdateContactUseCase: IUpdateContactUseCase 
    {
        private readonly IContatosRepository _contatosRepository;

        public UpdateContactUseCase(IContatosRepository contatosRepository)
        {
            _contatosRepository = contatosRepository;
        }

        public async Task ExecuteAsync(Contato contato)
        {
            await _contatosRepository.AtualizarContato(contato);
        }
    }
}
