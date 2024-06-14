using ContatosDeQuintoGrau.CoreBusiness;

namespace UseCases.Intefaces
{
    public interface IAddContactUseCase
    {
        Task ExecuteAsync(Contato contato);
    }
}
