﻿using Dapper;
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
    public class TurmaRepository : Repository, ITurmaRepository
    {
        public TurmaRepository(IOptions<ConnectionStringOption> connectionString) : base(connectionString) { }

        public Task AddAluno(string alunoId)
        {
            throw new NotImplementedException();
        }

        public async Task Create(Turma turma)
        {
            try
            {
                using (var connection = CreateOracleConnection())
                {
                    var parametros = new
                    {
                        id = Guid.NewGuid().ToString(),
                        serie = turma.Serie,
                        ano = turma.Ano
                    };

                    await connection.QueryAsync(@"INSERT INTO TURMA (ID, SERIE, ANO)
                                                VALUES(:id, :serie, :ano)", parametros);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro durante a criação da turma", ex);
            }
        }

        public async Task<IEnumerable<Turma>> Get()
        {
            try
            {
                using (var connection = CreateOracleConnection())
                {
                    //var turmas = await connection.QueryAsync<Turma>(@"SELECT ID, SERIE, ANO FROM TURMA");
                    var turmas = GetMock();
                    return turmas;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro durante a consulta de turmas.", ex);
            }
        }

        private List<Turma> GetMock()
        {
            var turmas = new List<Turma>
            {
                new Turma { Id = "AAA", Ano = 2020, Serie = 1 },
                new Turma { Id = "BBB", Ano = 2019, Serie = 2 },
                new Turma { Id = "CCC", Ano = 2018, Serie = 2 },
                new Turma { Id = "DDD", Ano = 2020, Serie = 3 }
            };

            return turmas;
        }
    }
}
