using CursosAPI.Dtos;
using CursosAPI.Exceptions;
using CursosAPI.Services;
using CursosAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudanteController : ControllerBase
    {

        private readonly IEstudanteService _estudanteService;

        public EstudanteController(IEstudanteService estudanteService)
        {
            _estudanteService = estudanteService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(Roles.ADMIN))]
        public async Task<IActionResult> GetAll()
        {
            var cursos = await _estudanteService.GetAllAsync();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = nameof(Roles.ADMIN))]
        public async Task<IActionResult> GetById(int id)
        {
            var curso = await _estudanteService.GetByIdAsync(id);

            if (curso == null)
            {
                return NotFound();
            }
            return Ok(curso);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [Authorize(Roles = nameof(Roles.ADMIN))]
        public async Task<IActionResult> Create([FromBody] CreateEstudanteDto dto)
        {
            try
            {
                await _estudanteService.CreateAsync(dto);
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

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = nameof(Roles.ADMIN))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEstudanteDto dto)
        {
            try
            {
                await _estudanteService.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = nameof(Roles.ADMIN))]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _estudanteService.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
