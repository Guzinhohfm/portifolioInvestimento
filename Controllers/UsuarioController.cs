using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portifolioInvestimento.DTOS;
using portifolioInvestimento.Interfaces;

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

           var usuario =  await _usuarioService.CriarUsuario(usuarioDTO);

            var newUsuario = new UsuarioDTO
            {
                Id = usuario.Id,
                Name = usuario.Name,
                Email = usuario.Email,
                TipoUsuario = usuario.TipoUsuario

            };

            return CreatedAtAction(nameof(ListarUsuariosPorId), new { Id = usuario.Id }, newUsuario);
        }

        [HttpGet("BuscarUsuarios")]

        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> listarUsuarios()
        {
            var usuariosDTO = await _usuarioService.listarUsuarios();

            if (usuariosDTO == null)
                return NotFound("Não há usuários criados");

            return Ok(usuariosDTO);

        }


        [HttpGet("BuscarUsuariosNome/{nome}", Name = "GetUsuarioNome")]

        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ListarUsuariosPorNome(string nome)
        {
            var usuariosDTO = await _usuarioService.ListarUsuarioPorNome(nome);

            if (usuariosDTO == null)
                return NotFound("Não há usuários criados com esse nome");

            return Ok(usuariosDTO);

        }


        [HttpGet("BuscarUsuarios/{id}", Name = "GetUsuarioId")]

        public async Task<ActionResult<UsuarioDTO>> ListarUsuariosPorId(int id)
        {
            var usuariosDTO = await _usuarioService.ListarUsuarioPorId(id);

            if (usuariosDTO == null)
                return NotFound("Não há usuários criados com esse ID");

            return Ok(usuariosDTO);

        }


        [HttpPut("EditarUsuario")]

        public async Task<ActionResult> EditarUsuario([FromBody] UsuarioDTO UsuarioDTO)
        {

            var UsuarioEditado = await _usuarioService.ListarUsuarioPorId(UsuarioDTO.Id);

            if (UsuarioEditado == null)
                return BadRequest("Não foi encontrado usuários com os dados fornecidos");

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
