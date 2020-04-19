using EducatioNow.Api.Data.Interfaces;
using EducatioNow.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducatioNow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public IProfessorRepository _professorRepository;

        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Professor>> Get()
        {
            var professores = await _professorRepository.GetProfessores();

            return professores;
        }

        [Route("adiciona")]
        [HttpPost]
        public async Task<IActionResult> Adiciona([FromBody] Professor professor)
        {
            if (professor is null)
            {
                return BadRequest();
            }

            await _professorRepository.Create(professor);
            return Ok();
        }
    }
}
