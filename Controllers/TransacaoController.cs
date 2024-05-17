using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portifolioInvestimento.DTOS;
using portifolioInvestimento.Services;

namespace portifolioInvestimento.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [HttpPost("Comprar")]

        public async Task<ActionResult<TransacaoDTO>> Comprar([FromBody] TransacaoDTO transacaoDTO)
        {
            if (transacaoDTO == null)
                return BadRequest("Dados inválidos");

            await _transacaoService.Comprar(transacaoDTO);

            return new CreatedAtRouteResult(new { id = transacaoDTO.investimentoId},
                transacaoDTO);
        }

        [HttpPost("Vender")]

        public async Task<ActionResult<TransacaoDTO>> Vender([FromBody] TransacaoDTO transacaoDTO)
        {
            if (transacaoDTO == null)
                return BadRequest("Dados inválidos");

            await _transacaoService.Comprar(transacaoDTO);

            return new CreatedAtRouteResult(new { id = transacaoDTO.investimentoId },
                transacaoDTO);
        }
    }
}
