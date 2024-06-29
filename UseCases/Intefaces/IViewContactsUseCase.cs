using ContatosDeQuintoGrau.CoreBusiness;
namespace UseCases.Intefaces
{
    public interface IViewContactsUseCase
    {
        Task<List<Contato>> ExecuteAsync(string filterText);
    }
}
