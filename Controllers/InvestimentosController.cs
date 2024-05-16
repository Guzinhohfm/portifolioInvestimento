using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portifolioInvestimento.Configuration;
using portifolioInvestimento.DTOS;
using portifolioInvestimento.Models;
using portifolioInvestimento.Services;

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

            await _investimentoService.AdicionarInvestimento(investimentoDTO);

            return new CreatedAtRouteResult("GetInvestimentoNome", new { nome = investimentoDTO.nome },
                investimentoDTO);
        }

        [HttpGet("BuscarInvestimentos")]

        public async Task<ActionResult<IEnumerable<InvestimentoDTO>>> ListarInvestimentos()
        {
            var investimentosDTO = await _investimentoService.ListarInvestimentos();

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
                return NotFound("Nenhum investimento com esse nome encontrado");
            return Ok(investimentoDTO);

        }


        [HttpPut("EditarInvestimento/{nome}")]
        
        public async Task<ActionResult> EditarInvestimento(string nome, [FromBody] InvestimentoDTO investimentoDTO)
        {
            if (nome != investimentoDTO.nome)
                return BadRequest();

            if(investimentoDTO == null)
                return BadRequest();

            await _investimentoService.EditarInvestimento(investimentoDTO);

            return Ok(investimentoDTO);
        }


        [HttpDelete("RemoverInvestimento/{id}")]

        public async Task<ActionResult<InvestimentoDTO>> RemoverInvestimento(int id) 
        {
            var investimentoDTO = await _investimentoService.ListarInvestimentoId(id);

            if (investimentoDTO == null)
            {
                return NotFound("Não localizado");
            }
               

            await _investimentoService.RemoverInvestimento(id);

            return Ok(investimentoDTO);

        }


    }
}
