using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Intefaces;
using UseCases.PluginsInterface;
using ContatosDeQuintoGrau.CoreBusiness;

namespace UseCases
{
    public class ViewContactUseCase : IViewContactUseCase
    {
        private readonly IContatosRepository _contactRepository;
        public ViewContactUseCase(IContatosRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<Contato> ExecuteAsync(Guid contactId)
        {
            return await _contactRepository.GetContactByIdAsync(contactId);
        }

        public async Task<List<Contato>> ExecuteAsync(string filterText)
        {
            return await _contactRepository.SearchContacts(filterText);
        }
    }
}
