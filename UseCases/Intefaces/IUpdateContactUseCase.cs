using ContatosDeQuintoGrau.CoreBusiness;
using UseCases.PluginsInterface;

namespace UseCases.Intefaces
{
    public interface IUpdateContactUseCase
    {      
        Task ExecuteAsync(Contato contato);       
    }
}
