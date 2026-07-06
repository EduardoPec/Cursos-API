using CursosAPI.Dtos;
using CursosAPI.Exceptions;
using CursosAPI.Services;
using CursosAPI.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscricaoController : ControllerBase
    {

        private readonly IInscricaoService _inscricaoService;

        public InscricaoController(IInscricaoService inscricaoService)
        {
            _inscricaoService = inscricaoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var inscricoes = await _inscricaoService.GetAllAsync();
            return Ok(inscricoes);
        }

        [HttpGet("estudantes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByEstudantes(int id)
        {
            var inscricoes = await _inscricaoService.GetByEstudanteIdAsync(id);

            if (inscricoes == null || !inscricoes.Any())
            {
                return NotFound($"Nenhuma inscrição encontrada! Id: {id}");
            }
            return Ok(inscricoes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var inscricao = await _inscricaoService.GetByIdAsync(id);

            if (inscricao == null)
            {
                return NotFound();
            }
            return Ok(inscricao);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateInscricaoDto dto)
        {
            try
            {
                await _inscricaoService.CreateAsync(dto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (DuplicatedException ex)
            { 
                return Conflict(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _inscricaoService.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
