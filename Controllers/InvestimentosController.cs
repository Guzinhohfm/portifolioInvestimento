using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portifolioInvestimento.Configuration;
using portifolioInvestimento.DTOS;
using portifolioInvestimento.Interfaces;
using portifolioInvestimento.Models;

namespace portifolioInvestimento.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class InvestimentosController : ControllerBase
    {
        private readonly IInvestimentoService _investimentoService;

        public InvestimentosController(IInvestimentoService investimentoService)
        {
            _investimentoService = investimentoService;
        }

        ///<summary>Inclui um novo produto de investimento ao sistema</summary>
        ///<param name="investimentoDTO">Objeto com os campos de envio necessários para a criação de um produto de investimento</param>
        ///<returns>ActionResult</returns>
        ///<response code="201">Retorno de criado caso seja inserido com sucesso</response>

        [HttpPost("AdicionarNovoInvestimento")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<InvestimentoDTO>> AdicionarInvestimento([FromBody] InvestimentoDTO investimentoDTO)
        {
            if (investimentoDTO == null)
                return BadRequest("Dados inválidos");

           var investimento =  await _investimentoService.AdicionarInvestimento(investimentoDTO);

            var newInvestimento = new InvestimentoDTO
            {
                Id = investimento.Id,
                nome = investimento.nome,
                TipoRisco = investimento.TipoRisco,
                validadeProduto = investimento.validadeProduto
            };

            return CreatedAtAction(nameof(ListarInvestimentoPorId), new { Id = investimento.Id }, newInvestimento);
            }

        /// <summary>
        /// Retornará todos os investimentos ativos no sistema
        /// </summary>
        /// <param name="skip">Número de elementos que deseja **pular** na pesquisa</param>
        /// <param name="take">Número de elementos que deseja **pegar** da pesquisa</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorno caso seja realizado com sucesso</response>

        [HttpGet("BuscarInvestimentos", Name = "GetInvestimento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InvestimentoDTO>>> ListarInvestimentos([FromQuery]
                    int skip = 0, int take = 10)
        {
            var investimentosDTO = await _investimentoService.ListarInvestimentos(skip, take);

            if (investimentosDTO == null)
                return NotFound("Não há investimentos criados");


            return Ok(investimentosDTO);
            
        }

        /// <summary>
        /// Retornará o produto cadastrado no sistema pelo nome do investimento informado 
        /// </summary>
        /// <param name="nome">Nome do produto de investimento desejado</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorno caso seja realizado com sucesso</response>

        [HttpGet("BuscarInvestimentoNome/{nome}", Name = "GetInvestimentoNome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InvestimentoDTO>> ListarInvestimentoPorNome(string nome)
        {
            var investimentoDTO = await _investimentoService.ListarInvestimentoNome(nome);

            if (investimentoDTO == null)
                return NotFound("Nenhum investimento com esse nome encontrado");
            return Ok(investimentoDTO);
            
        }

        /// <summary>
        /// Retornará o produto cadastrado no sistema pelo id do investimento informado 
        /// </summary>
        /// <param name="id">Número do id do produto de investimento</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorno caso seja realizado com sucesso</response>


        [HttpGet("BuscarInvestimentoId/{id}", Name = "GetInvestimentoId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InvestimentoDTO>> ListarInvestimentoPorId(int id)
        {
            var investimentoDTO = await _investimentoService.ListarInvestimentoId(id);

            if (investimentoDTO == null)
                return NotFound("Nenhum investimento com esse ID encontrado");
            return Ok(investimentoDTO);

        }

        /// <summary>
        /// Editará um produto de investimento cadastrado no sistema
        /// </summary>
        /// <param name="id">Número de id do produto de investimento</param>
        /// <param name="investimentoDTO">Objeto contendo os dados que deseja alterar</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorno caso seja realizado com sucesso</response>


        [HttpPut("EditarInvestimento/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> EditarInvestimento(int id, [FromBody] InvestimentoDTO investimentoDTO)
        {
            if (investimentoDTO.Id != id)
                return BadRequest();

            if(investimentoDTO == null)
                return BadRequest();

            await _investimentoService.EditarInvestimento(investimentoDTO);

            return Ok(investimentoDTO);
        }


        /// <summary>
        /// Desativará um produto de investimento que não é mais utilizado
        /// </summary>
        /// <param name="id">Número do id do produto desejado</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorno caso seja realizado com sucesso</response>

        [HttpPut("DesativarInvestimento/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InvestimentoDTO>> RemoverInvestimento(int id)
        {
            var investimentoDTO = await _investimentoService.ListarInvestimentoId(id);

            if (investimentoDTO == null)
            {
                return NotFound("Não localizado");
            }


            await _investimentoService.DesativarInvestimento(id);

            return Ok(investimentoDTO);

        }


    }
}
