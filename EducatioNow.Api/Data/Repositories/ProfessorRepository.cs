using Dapper;
using EducatioNow.Api.Data.Interfaces;
using EducatioNow.Api.Models;
using EducatioNow.Api.Utils;
using EducatioNow.Infra.Data.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducatioNow.Api.Data.Repositories
{
    public class ProfessorRepository : Repository, IProfessorRepository
    {
        public ProfessorRepository(IOptions<ConnectionStringOption> connectionString) : base(connectionString) { }

        public async Task AddNaTurma(string professorId, string turmaId)
        {
            throw new NotImplementedException();
        }

        public async Task Create(Professor professor)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Professor>> GetProfessores()
        {
            try
            {
                using (var connection = CreateOracleConnection())
                {
                    var professores = await connection.QueryAsync<Professor>("SELECT ID, NOME, EMAIL, DTNASCIMENTO FROM PROFESSOR");
                    return professores;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro durante a consulta de professores.", ex);
            }
        }
    }
}
