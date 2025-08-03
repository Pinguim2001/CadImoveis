using CadImoveis.Application.DTOs;
using CadImoveis.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadImoveis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImoveisController : ControllerBase
    {
        private readonly CadastroService CadService;

        public ImoveisController(CadastroService _cadastroService)
        {
            CadService = _cadastroService;
        }

        [HttpPost("proprietario")]
        public IActionResult CriarProprietario([FromBody] ProprietarioDto _dto)
        {
            var id = CadService.CriarProprietario(_dto);
            return Ok(new { Id = id });
        }
        [HttpPost("imovel")]
        public IActionResult AdicionarImovel([FromBody] ImovelDto _dto)
        {
            var id = CadService.AddImovel(_dto);
            return Ok(new { Id = id });
        }
        [HttpPost("finalizar/{imovelId}")]
        public IActionResult FinalizarCadastro(Guid _imovelId)
        {
            CadService.FinalizarCadastro(_imovelId);
            return NoContent();

        }
        [HttpGet("resumo/{imovelId}")]
        public IActionResult ObterResumo(Guid _imovelId)
        {
            var resumo = CadService.GetResumo(_imovelId);
            return Ok(resumo);
        }

        [HttpGet("proprietario/{documento}")]
        public IActionResult GetProprietarioByDoc(string _documento)
        {
            var proprietario = CadService.GetProprietarioByDoc(_documento);

            if (proprietario == null)
                return NotFound("Proprietario Não encontrado");

            return Ok(new
            {
                proprietario.Id,
                proprietario.Nome,
                proprietario.Doc,
                Imoveis = proprietario.Imoveis?.Select(i => new
                {
                    i.Id,
                    i.Area,
                    i.Endereco,
                    i.Etapa,
                    i.Finalizado
                }),
            });
        }

        [HttpGet("retomar/{imovelId}")]
        public IActionResult? RetomarCadastro(Guid _imovelId)
        {
            var imovel = CadService.RetomarCadastro(_imovelId);
            if (imovel == null)
                return NotFound("Imóvel não encontrado ou já finalizado");

            return Ok(new
            {
                imovel.Id,
                imovel.IdProprietario,
                imovel.Area,
                imovel.Endereco,
                imovel.Etapa,
                imovel.Finalizado
            });
        }

        [HttpGet("todos")]
        public IActionResult? ListarTodos()
        {
            var cadastros = CadService.ListarCadastros();
            return Ok(cadastros);
        }

        [HttpGet("valortotal/{documento}")]
        public IActionResult? CalcValorTotal(string _documento)
        {
            try
            {
                var total = CadService.CalcValorTotal(_documento);
                return Ok(total);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}

