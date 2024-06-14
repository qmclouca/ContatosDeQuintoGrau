using ContatosDeQuintoGrau.CoreBusiness;

namespace UseCases.Intefaces
{
    public interface IDeleteContactUseCase
    {
        Task ExecuteAsync(Contato contato);
    }
}
