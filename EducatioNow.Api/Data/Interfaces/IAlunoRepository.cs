using EducatioNow.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducatioNow.Api.Data.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAlunos();

        Task Create(Aluno aluno);

        Task AddNaTurma(int alunoId, string turmaId);
    }
}
