using EducatioNow.Api.Data.Interfaces;
using EducatioNow.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducatioNow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Aluno>> RetornaAlunos()
        {
            var alunos = await _alunoRepository.GetAlunos();

            return alunos;
        }
        [Route("adiciona")]
        [HttpPost]
        public async Task<IActionResult> AdicionaAluno([FromBody] Aluno aluno)
        {
            if (aluno is null)
            {
                return BadRequest();
            }

            await _alunoRepository.Create(aluno);

            return Ok();
        }
    }
}
