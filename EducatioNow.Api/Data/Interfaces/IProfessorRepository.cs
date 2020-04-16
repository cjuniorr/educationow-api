using EducatioNow.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducatioNow.Api.Data.Interfaces
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> GetProfessors();

        Task Create(Professor professor);

        Task AddNaTurma(string professorId, string turmaId);
    }
}
