using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portifolioInvestimento.Configuration;
using portifolioInvestimento.Models;

namespace portifolioInvestimento.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class InvestimentosController : ControllerBase
    {
        private readonly PortifolioDbContext _context;
      
        public InvestimentosController(PortifolioDbContext context)
        {
            _context = context;
        }

     
        [HttpPost("AdicionarNovoInvestimento")]
        
        public IActionResult AdicionarInvestimento([FromBody] Investimento investimento)
        {
            investimento.Guid = RandomizarId.GerarIdUnico();
            _context.investimentos.Add(investimento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListarInvestimentosPorNome), new { nome = investimento.nome }
            , investimento);
        }

        [HttpGet("BuscarInvestimentos")]

        public IEnumerable<Investimento> ListarInvestimentos([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _context.investimentos.Skip(skip).Take(take);
        }

        [HttpGet("BuscarInvestimento/{nome}")]
       
        public IActionResult ListarInvestimentosPorNome(string nome) //Usando nullable pois item pode vir vazio
        {
            var investimento = _context.investimentos
                .FirstOrDefault(investimento => investimento.nome == nome);

            if (investimento == null) return NotFound();
            return Ok(investimento);
        }


        [HttpPut("EditarInvestimento")]
        
        public void EditarInvestimento()
        {

        }

        [HttpPost("transacao/comprar")]
        public void ComprarTransacao()
        {

        }

        [HttpPost("transacao/vender")]
      
        public void VenderTransacao()
        {

        }
    }
}
