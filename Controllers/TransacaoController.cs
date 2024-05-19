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

        /// <summary>
        /// Serviço para realização de uma compra do produto de investimento
        /// </summary>
        /// <param name="transacaoDTO">Objeto em que é passado os dados necessários para efetuar a compra</param>
        /// <returns>ActionResult</returns>
        /// <response code="201">Retorno caso operação seja realizada com sucesso</response>

        [HttpPost("Comprar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TransacaoDTO>> Comprar([FromBody] TransacaoDTO transacaoDTO)
        {
            if (transacaoDTO == null)
                return BadRequest("Dados inválidos");

            if (transacaoDTO.ValorTransacao <= 0)
                return BadRequest("valor da transação deve ser maior que 0");

            var transacao = await _transacaoService.Comprar(transacaoDTO);

            var newTransacaoCompra = new TransacaoDTO
            {
                ClientId = transacao.ClientId,
                InvestimentoId = transacao.InvestimentoId,
                NomeInvestimento = transacao.NomeInvestimento,
                TipoTransacao = transacao.TipoTransacao,
                ValorTransacao = transacao.ValorTransacao

            };

            return new CreatedAtRouteResult(new { clientId = transacao.ClientId, investimentoId = transacao.InvestimentoId},
                newTransacaoCompra);
        }

        /// <summary>
        /// Serviço para realização de uma venda do produto de investimento
        /// </summary>
        /// <param name="transacaoDTO">Objeto em que é passado os dados necessários para efetuar a venda</param>
        /// <returns>ActionResult</returns>
        /// <response code="201">Retorno caso operação seja realizada com sucesso</response>

        [HttpPost("Vender")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TransacaoDTO>> Vender([FromBody] TransacaoDTO transacaoDTO)
        {
            if (transacaoDTO == null)
                return BadRequest("Dados inválidos");

            var transacao = await _transacaoService.Vender(transacaoDTO);

            var newTransacaoVenda = new TransacaoDTO
            {
                ClientId = transacao.ClientId,
                InvestimentoId = transacao.InvestimentoId,
                NomeInvestimento = transacao.NomeInvestimento,
                TipoTransacao = transacao.TipoTransacao,
                ValorTransacao = transacao.ValorTransacao

            };

            return new CreatedAtRouteResult(new { clientId = transacao.ClientId, investimentoId = transacao.InvestimentoId },
                newTransacaoVenda);
        }

        /// <summary>
        /// Gerar o extrato do usuário com base no produto de investimento desejado
        /// </summary>
        /// <param name="investimentoId">Número do id do produto de investimento desejado</param>
        /// <param name="clientId">Número do id do usuário</param>
        /// <param name="skip">Número de elementos que deseja **pular** na pesquisa</param>
        /// <param name="take">Número de elementos que deseja **pegar** na pesquisa</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorno caso operação seja realizada com sucesso</response>


        [HttpGet("GerarExtratoPorInvestimento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransacaoDTO>>> GerarExtratoInvestimento([FromQuery] 
        int investimentoId, int clientId, int skip = 0, int take = 10)
        {
            var extratoInvestimento = await _transacaoService.
                GerarExtratoPorInvestimento(investimentoId, clientId, skip, take);

            if (extratoInvestimento == null)
                return NotFound("Não há investimentos comprados");

            return Ok(extratoInvestimento);
        }

        /// <summary>
        /// Serviço que retorna um extrato geral por usuário
        /// </summary>
        /// <param name="clientId">Número do id do usuário</param>
        /// <param name="skip">Número de elementos que deseja **pular** na pesquisa</param>
        /// <param name="take">Número de elementos que deseja **pegar** na pesquisa</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorno caso operação seja realizada com sucesso</response>

        [HttpGet("GerarExtratoTotal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransacaoDTO>>> GerarExtratoTotalCliente([FromQuery]
                int clientId, int skip = 0, int take = 10)
        {
            var extratoInvestimento = await _transacaoService.GerarExtratoTotalCliente(clientId, skip, take);
            
            if (extratoInvestimento == null)
                return NotFound("Não há investimentos comprados");

           

            return Ok(extratoInvestimento);
        }

    }
}
