using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using portifolioInvestimento.Interfaces;

namespace portifolioInvestimento.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEnviadorEmail _enviadorEmail;

        public EmailController(IEnviadorEmail enviadorEmail)
        {
            _enviadorEmail = enviadorEmail;
        }

        [HttpPost("EnviarEmail")]

        public async Task<IActionResult> EnviarEmail()
        {
            var receptor = "lucabtei@outlook.com";
            var assunto = "Teste serviço email";
            var mensagem = "Oi lUCAS, isso é um teste";

            await _enviadorEmail.EnviarEmail(receptor, assunto, mensagem);


            return Ok();
        }

    }
}
