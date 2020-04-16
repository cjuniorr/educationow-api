using EducatioNow.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducatioNow.Api.Data.Interfaces
{
    public interface ITurmaRepository
    {
        Task<IEnumerable<Turma>> Get();

        Task Create(Turma turma);

        Task AddAluno(string alunoId);
    }
}
