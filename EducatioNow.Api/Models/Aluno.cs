﻿using System;

namespace EducatioNow.Domain.Models
{
    public class Aluno
    {
        public int? Id { get; set; }

        public string TurmaId { get; set; }

        public string Nome { get; set; }

        public string EnderecoId { get; set; }

        public string TelefoneId { get; set; }

        public string Email { get; set; }

        public DateTime DtNascimento { get; set; }
    }
}
