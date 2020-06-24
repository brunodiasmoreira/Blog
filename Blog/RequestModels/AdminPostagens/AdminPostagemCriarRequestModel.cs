using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.RequestModels.AdminPostagens
{
    public class AdminPostagemCriarRequestModel
    {
        public string Titulo { get; set; }

        public string Texto { get; set; }

        public string Descricao { get; set; }

        public string DataPostagem { get; set; }

        public int IdAutor { get; set; }

        public int IdCategoria { get; set; }
    }
}
