using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Exemplo.Application.Service;
using Exemplo.Application.ViewModel;

namespace Exemplo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : Controller
    {
        private readonly ILogger<ContatoController> _logger;
        private readonly IContatoService _contatoService;

        public ContatoController(ILogger<ContatoController> logger, IContatoService contatoService)
        {
            _logger = logger;
            _contatoService = contatoService;
        }

        [HttpPost]
        [Route("SalvarNovo")]
        public IActionResult SalvarNovo([FromBody] ContatoViewModel viewModel)
        {
            var model = _contatoService.Incluir(viewModel).Result;

            if (model != null && String.IsNullOrEmpty(model.Erro))
                return Ok(model);
            else return BadRequest(model.Erro);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ListarTodos")]
        public async Task<IEnumerable<ContatoViewModel>> ListarTodos()
        {
            return await _contatoService.GetAll();
        }

        [HttpGet("DetalheContato/{id}")]
        public async Task<IActionResult> DetalheContato(int id)
        {
            var retorno = await _contatoService.RetornaPorId(id);
            if (retorno != null) return Ok(retorno);
            else return NotFound("Contato não existente");
        }


        [HttpPut]
        [Route("Desativar")]
        public IActionResult Desativar(int id)
        {
            var model = _contatoService.Desativar(id).Result;

            if (model != null && String.IsNullOrEmpty(model.Erro))
                return Ok(model);
            else return BadRequest(model.Erro);
        }

        [HttpDelete("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            var result = _contatoService.Excluir(id).Result;

            if (result != null && String.IsNullOrEmpty(result.Erro)) return Ok(result);
            else return BadRequest(result.Erro);
        }

    }
}