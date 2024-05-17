using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portifolioInvestimento.DTOS;
using portifolioInvestimento.Services;

namespace portifolioInvestimento.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("CriarUsuario")]

        public async Task<ActionResult<UsuarioDTO>> CriarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return BadRequest("Dados inválidos");

            await _usuarioService.CriarUsuario(usuarioDTO);

            return new CreatedAtRouteResult(new { nome = usuarioDTO.Name, tipo = usuarioDTO.TipoUsuario.ToString() },
                usuarioDTO);
        }

        [HttpGet("BuscarUsuarios")]

        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> listarUsuarios()
        {
            var usuariosDTO = await _usuarioService.listarUsuarios();

            if (usuariosDTO == null)
                return NotFound("Não há usuários criados");

            return Ok(usuariosDTO);

        }


        [HttpGet("BuscarUsuarios/{nome}", Name = "GetUsuarioNome")]

        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ListarUsuariosPorNome(string nome)
        {
            var usuariosDTO = await _usuarioService.ListarUsuarioPorNome(nome);

            if (usuariosDTO == null)
                return NotFound("Não há usuários criados com esse nome");

            return Ok(usuariosDTO);

        }


        [HttpGet("BuscarUsuarios/{id}", Name = "GetUsuarioId")]

        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ListarUsuariosPorId(int id)
        {
            var usuariosDTO = await _usuarioService.ListarUsuarioPorId(id);

            if (usuariosDTO == null)
                return NotFound("Não há usuários criados com esse ID");

            return Ok(usuariosDTO);

        }

        [HttpPut("EditarUsuario/{nome}")]

        public async Task<ActionResult> EditarUsuario(string nome, [FromBody] UsuarioDTO UsuarioDTO)
        {
            if (nome != UsuarioDTO.Name)
                return BadRequest();

            if (UsuarioDTO == null)
                return BadRequest();

            await _usuarioService.EditarUsuario(UsuarioDTO);

            return Ok(UsuarioDTO);
        }


        [HttpDelete("RemoverUsuario/{id}")]

        public async Task<ActionResult<InvestimentoDTO>> RemoverUsuarip(int id)
        {
            var usuarioDTO = await ListarUsuariosPorId(id);

            if (usuarioDTO == null)
            {
                return NotFound("Não localizado");
            }


            await _usuarioService.RemoverUsuario(id);

            return Ok(usuarioDTO);

        }

    }
}
