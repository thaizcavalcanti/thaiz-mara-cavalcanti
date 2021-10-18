using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exemplo.Application.ViewModel;

namespace Exemplo.Application.Service
{
    public interface IContatoService
    {
        Task<IEnumerable<ContatoViewModel>> GetAll();
        Task<ContatoViewModel> RetornaPorId(int id);
        Task<ContatoViewModel> Incluir(ContatoViewModel obj);
        Task<ContatoViewModel> Desativar(int id);
        Task<ContatoViewModel> Excluir(int id);
    }

}
