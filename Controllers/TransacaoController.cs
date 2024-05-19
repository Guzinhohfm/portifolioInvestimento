using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portifolioInvestimento.DTOS;
using portifolioInvestimento.Interfaces;

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

            if (transacaoDTO.ValorTransacao <= 0)
                return BadRequest("valor da transação deve ser maior que 0");

            await _transacaoService.Comprar(transacaoDTO);

            return new CreatedAtRouteResult(new { id = transacaoDTO.InvestimentoId},
                transacaoDTO);
        }


        [HttpPost("Vender")]

        public async Task<ActionResult<TransacaoDTO>> Vender([FromBody] TransacaoDTO transacaoDTO)
        {
            if (transacaoDTO == null)
                return BadRequest("Dados inválidos");

            await _transacaoService.Vender(transacaoDTO);


            return new CreatedAtRouteResult(new { id = transacaoDTO.InvestimentoId },
                transacaoDTO);
        }


        [HttpGet("GerarExtratoPorInvestimento")]

        public async Task<ActionResult<IEnumerable<TransacaoDTO>>> GerarExtratoInvestimento([FromQuery] 
        int investimentoId, int clientId, int skip, int take)
        {
            var extratoInvestimento = await _transacaoService.
                GerarExtratoPorInvestimento(investimentoId, clientId, skip, take);

            if (extratoInvestimento == null)
                return NotFound("Não há investimentos comprados");

            return Ok(extratoInvestimento);
        }


        [HttpGet("GerarExtratoTotal")]

        public async Task<ActionResult<IEnumerable<TransacaoDTO>>> GerarExtratoTotalCliente([FromQuery]
                int clientId, int skip, int take)
        {
            var extratoInvestimento = await _transacaoService.GerarExtratoTotalCliente(clientId, skip, take);

            if (extratoInvestimento == null)
                return NotFound("Não há investimentos comprados");

           
            return Ok(extratoInvestimento);
        }

    }
}
