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
        public IAlunoRepository _alunoRepository { get; }

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        // GET: api/Aluno
        [HttpGet]
        public async Task<IEnumerable<Aluno>> Get()
        {
            var alunos = await _alunoRepository.GetAlunos();

            return alunos;
        }

        // GET: api/Aluno/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Aluno
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
