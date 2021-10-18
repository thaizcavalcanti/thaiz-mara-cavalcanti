using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exemplo.Application.ViewModel;
using Exemplo.Domain.Entities;
using Exemplo.Repository.Data.Repositories;

namespace Exemplo.Application.Service
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly ILogger<IContatoService> _logger;
        private readonly IMapper _mapper;

        public ContatoService(ILogger<IContatoService> logger, IMapper mapper, IContatoRepository cadastroTesteRepository)
        {
            _contatoRepository = cadastroTesteRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContatoViewModel>> GetAll()
        {
            var obj = _contatoRepository.AsQueryable().Where(p => p.IsAtivo == true);
            return _mapper.Map<IEnumerable<ContatoViewModel>>(obj);
        }

        public async Task<ContatoViewModel> RetornaPorId(int id)
        {
            var obj = _contatoRepository.GetById(id).Result;

            if (obj != null && obj.IsAtivo)
                return _mapper.Map<ContatoViewModel>(obj);
            else
                return new ContatoViewModel { Erro = "Nenhum contato ativo encontrado!" };
        }

        public async Task<ContatoViewModel> Incluir(ContatoViewModel pObj)
        {
            var objRetorno = new ContatoViewModel();

            pObj.Idade = CalcularIdade(pObj);
            objRetorno.Erro = Validacao.ValidarContato.ValidarDados(pObj);

            if (objRetorno.Erro != "")
                objRetorno.Erro = "Erro ao incluir dados! " + objRetorno.Erro;
            else
            {
                try
                {
                    var lObj = _mapper.Map<Contato>(pObj);
                    var result = await _contatoRepository.Insert(lObj);
                    objRetorno = _mapper.Map<ContatoViewModel>(lObj);
                }
                catch (Exception ex)
                {
                    objRetorno.Erro = "Erro ao incluir dados! " + ex.Message;
                }
            }
            
            return objRetorno;
        }

        public async Task<ContatoViewModel> Excluir(int id)
        {
            var retorno = new ContatoViewModel();

            try
            {
                var obj = _contatoRepository.GetById(id).Result;

                if(obj == null)
                    retorno.Erro = "Contato não encontrado!";
                else
                {
                    _contatoRepository.Delete(obj);
                    await _contatoRepository.Commit();
                }
            }
            catch (Exception ex)
            {
                retorno.Erro = "Erro ao excluir Contato! " + ex.Message; 

            }
            
            return retorno;
        }

        public async Task<ContatoViewModel> Desativar(int id)
        {
            var model = new ContatoViewModel();
            try
            {
                var obj = _contatoRepository.GetById(id).Result;
                obj.IsAtivo = false;
                await _contatoRepository.Update(obj);
                await _contatoRepository.Commit();

                model = _mapper.Map<ContatoViewModel>(obj);
            }
            catch (Exception ex)
            {
                model.Erro = "Erro ao incluir dados! " + ex.Message;
            }

            return model;
        }

        public static int CalcularIdade(ContatoViewModel obj)
        {
            var dataNascimento = obj.DataNascimento;
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }
    }
}
