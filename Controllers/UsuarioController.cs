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


        /// <summary>
        /// Criar um novo usuário no sistema
        /// </summary>
        /// <param name="usuarioDTO">Objeto com os dados necessários para criação do usuário</param>
        /// <returns>ActionResult</returns>
        /// <response code="201">Retornará caso a operação seja realizada com sucesso</response>
        [HttpPost("CriarUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]

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

        /// <summary>
        /// Retornará todos os usuários cadastrados no sistema
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200"></response>
        [HttpGet("BuscarUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> listarUsuarios()
        {
            var usuariosDTO = await _usuarioService.listarUsuarios();

            if (usuariosDTO == null)
                return NotFound("Não há usuários criados");

            return Ok(usuariosDTO);

        }

        /// <summary>
        /// Retornará todos os usuários administradores cadastrados no sistema
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200"></response>
        [HttpGet("BuscarUsuariosADM")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ObterUsuariosAdm()
        {
            var usuariosDTO = await _usuarioService.ObterUsuariosAdm();


            return Ok(usuariosDTO);

        }


        /// <summary>
        /// Retornará um usuário pelo nome cadastrado no sistema
        /// </summary>
        /// <param name="nome">Nome do usuário que deseja buscar</param>
        /// <returns>ActionResult</returns>
        /// <response code="200"></response>
        [HttpGet("BuscarUsuariosNome/{nome}", Name = "GetUsuarioNome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ListarUsuariosPorNome(string nome)
        {
            var usuariosDTO = await _usuarioService.ListarUsuarioPorNome(nome);

            if (usuariosDTO == null)
                return NotFound("Não há usuários criados com esse nome");

            return Ok(usuariosDTO);

        }

        /// <summary>
        /// Retornará um usuário pelo id cadastrado no sistema
        /// </summary>
        /// <param name="id">Nome do usuário que deseja buscar</param>
        /// <returns>ActionResult</returns>
        /// <response code="200"></response>

        [HttpGet("BuscarUsuarios/{id}", Name = "GetUsuarioId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UsuarioDTO>> ListarUsuariosPorId(int id)
        {
            var usuariosDTO = await _usuarioService.ListarUsuarioPorId(id);

            if (usuariosDTO == null)
                return NotFound("Não há usuários criados com esse ID");

            return Ok(usuariosDTO);

        }

        /// <summary>
        /// Editará um usuário cadastrado no sistema
        /// </summary>
        /// <param name="UsuarioDTO">Objeto com os dados que deseja editar</param>
        /// <returns>ActionResult</returns>
        /// <response code="200"></response>

        [HttpPut("EditarUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>
        /// Deletará um usuário cadastrado no sistema
        /// </summary>
        /// <param name="id">Número id do usuário que deseja deletar</param>
        /// <returns>ActionResult</returns>
        /// <response code="200"></response>

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
