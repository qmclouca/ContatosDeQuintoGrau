﻿using ContatosDeQuintoGrau.CoreBusiness;
using UseCases.Intefaces;
using UseCases.PluginsInterface;

namespace UseCases
{
    public class DeleteContactUseCase: IDeleteContactUseCase
    {
        private readonly IContatosRepository _contatosRepository;

        public DeleteContactUseCase(IContatosRepository contatosRepository)
        {
            _contatosRepository = contatosRepository;
        }
        public async Task ExecuteAsync(Contato contato)
        {
            await _contatosRepository.RemoverContato(contato);
        }
    }
}
