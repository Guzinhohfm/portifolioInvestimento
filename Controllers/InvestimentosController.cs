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

        [HttpPost("AdicionarNovoInvestimento")]
        
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

        [HttpGet("BuscarInvestimentos", Name = "GetInvestimento")]

        public async Task<ActionResult<IEnumerable<InvestimentoDTO>>> ListarInvestimentos([FromQuery]
                    int skip = 0, int take = 10)
        {
            var investimentosDTO = await _investimentoService.ListarInvestimentos(skip, take);

            if (investimentosDTO == null)
                return NotFound("Não há investimentos criados");


            return Ok(investimentosDTO);
            
        }

        [HttpGet("BuscarInvestimentoNome/{nome}", Name = "GetInvestimentoNome")]
       
       public async Task<ActionResult<InvestimentoDTO>> ListarInvestimentoPorNome(string nome)
        {
            var investimentoDTO = await _investimentoService.ListarInvestimentoNome(nome);

            if (investimentoDTO == null)
                return NotFound("Nenhum investimento com esse nome encontrado");
            return Ok(investimentoDTO);
            
        }

        [HttpGet("BuscarInvestimentoId/{id}", Name = "GetInvestimentoId")]

        public async Task<ActionResult<InvestimentoDTO>> ListarInvestimentoPorId(int id)
        {
            var investimentoDTO = await _investimentoService.ListarInvestimentoId(id);

            if (investimentoDTO == null)
                return NotFound("Nenhum investimento com esse ID encontrado");
            return Ok(investimentoDTO);

        }


        [HttpPut("EditarInvestimento/{id}")]
        
        public async Task<ActionResult> EditarInvestimento(int id, [FromBody] InvestimentoDTO investimentoDTO)
        {
            if (investimentoDTO.Id != id)
                return BadRequest();

            if(investimentoDTO == null)
                return BadRequest();

            await _investimentoService.EditarInvestimento(investimentoDTO);

            return Ok(investimentoDTO);
        }


        [HttpPut("DesativarInvestimento/{id}")]

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
