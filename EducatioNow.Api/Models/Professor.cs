﻿using System;

namespace EducatioNow.Api.Models
{
    public class Professor
    {
        public string Nome { get; set; }

        public int? Id { get; set; }

        public string Email { get; set; }

        public DateTime DtNascimento { get; set; }
    }
}
