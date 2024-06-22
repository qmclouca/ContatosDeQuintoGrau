using ContatosDeQuintoGrau.CoreBusiness;
namespace UseCases.Intefaces
{
    public interface IViewContactUseCase
    {
        Task<Contato> ExecuteAsync(Guid contactId);
    }
}
