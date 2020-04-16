﻿using Dapper;
using EducatioNow.Api.Data.Interfaces;
using EducatioNow.Api.Utils;
using EducatioNow.Domain.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducatioNow.Infra.Data.Repositories
{
    public class AlunoRepository : Repository, IAlunoRepository
    {
        public AlunoRepository(IOptions<ConnectionStringOption> connectionString) : base(connectionString) { }

        public async Task AddNaTurma(int alunoId, string turmaId)
        {
            try
            {
                var parametro = new
                {
                    turmaId = turmaId,
                    alunoId = alunoId
                };

                //using (var connection = CreateOracleConnection())
                //{
                //    await connection.QueryAsync(@"INSERT INTO ALUNO (TURMAID) VALUES(:turmaId) WHERE ID = :alunoId");
                //}
            }
            catch (Exception ex)
            {

                throw new Exception("Erro durante a inserção do aluno na turma.", ex);
            }
        }

        public async Task Create(Aluno aluno)
        {
            try
            {
                using (var connection = CreateOracleConnection())
                {
                    var idUltimoAluno = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT ID FROM ALUNO ORDER BY ID DESC");
                    var parametros = new
                    {
                        Id = idUltimoAluno + 1,
                        TurmaId = aluno.TurmaId,
                        Nome = aluno.Nome,
                        EnderecoId = aluno.EnderecoId,
                        TelefoneId = aluno.TelefoneId,
                        Email = aluno.Email,
                        DtNascimento = DateTime.Now
                    };

                    await connection.QueryAsync<Aluno>(@"INSERT INTO RM83652.ALUNO (ID, TURMAID, NOME, ENDERECOID, TELEFONEID, EMAIL, DTNASCIMENTO)
                                                        VALUES(:Id, :TurmaId, :Nome, :EnderecoId, :TelefoneId, :Email, :DtNascimento)", parametros);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro durante a criação do aluno.", ex);
            }
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            try
            {
                using (var connection = CreateOracleConnection())
                {
                    //var alunos = await connection.QueryAsync<Aluno>(@"SELECT ID, TURMAID, NOME, ENDERECOID, TELEFONEID, EMAIL, DTNASCIMENTO FROM ALUNO");

                    var alunos = GetMock();
                    return alunos;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro durante a busca do aluno.", ex);
            }
        }

        private IEnumerable<Aluno> GetMock()
        {
            var alunos = new List<Aluno> {
                new Aluno { Id = 1, Nome = "Fulano", DtNascimento = DateTime.Now, Email = "bb@aa.com", EnderecoId = "Rua eqwewq", TelefoneId = "11111111111" },
                new Aluno { Id = 1, Nome = "Beltrano", DtNascimento = DateTime.Now, Email = "cc@aa.com", EnderecoId = "Rua eqweqw", TelefoneId = "222222222" },
                new Aluno { Id = 1, Nome = "Sicrano", DtNascimento = DateTime.Now, Email = "aa@aa.com", EnderecoId = "Rua seieqwqla", TelefoneId = "33333" },
                new Aluno { Id = 1, Nome = "Deltrano", DtNascimento = DateTime.Now, Email = "www@aa.com", EnderecoId = "Rua seila", TelefoneId = "77777" },
            };

            return alunos;
        }
    }
}
