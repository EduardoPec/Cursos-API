using CursosAPI.Dtos;
using CursosAPI.Exceptions;
using CursosAPI.Services;
using CursosAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CreateUsuarioDto dto)
        {
            try
            {
                await _usuarioService.Cadastra(dto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (FalhaCadastroException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LogarUsuario([FromBody] LoginUsuarioDto dto)
        {
            try
            {
                var token = await _usuarioService.Login(dto);
                return Ok(token);
            }
            catch (NaoAutenticadoException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
