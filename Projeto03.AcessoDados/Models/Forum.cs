﻿using System.ComponentModel.DataAnnotations;

namespace Projeto03.AcessoDados.Models
{
    public class Forum
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }
        public string? Descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public string? Responsavel { get; set; }
        public string? Telefone { get; set; }

        public ICollection<Comentario>? Comentarios { get; set; }
    }
}
