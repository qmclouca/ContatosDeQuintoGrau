using ContatosDeQuintoGrau.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Intefaces;
using UseCases.PluginsInterface;

namespace UseCases
{
    public class ViewContactsUseCase : IViewContactsUseCase
    {
        private readonly IContatosRepository _contactRepository;

        public ViewContactsUseCase(IContatosRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<List<Contato>> ExecuteAsync(string filterText)
        {
            return await _contactRepository.SearchContacts(filterText);
        }
    }
}
