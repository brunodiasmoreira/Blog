﻿using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Blog.Postagem.Classificacao
{
    public class ClassificacaoEntity
    {
        [Key]
        public int Id { get; set; }
        
        public PostagemEntity Postagem { get; set; }
        
        [Required]
        public bool Classificacao { get; set; }
    }
}
