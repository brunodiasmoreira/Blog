using Blog.Models.Blog.Autor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers.Admin
{
    public class AdminAutoresController : Controller
    {
        private readonly AutorOrmService _autoresOrmService;

        public AdminAutoresController(
            AutorOrmService autoresOrmService
        )
        {
            _autoresOrmService = autoresOrmService;
        }

        [HttpGet]
        [Route("admin/autores")]
        [Route("admin/autores/listar")]
        public string Listar()
        {
            return "listar autores";
        }

        [HttpPost]
        [Route("admin/autores/criar")]
        public string Criar()
        {
            return "criar autor";
        }

        [HttpPost]
        [Route("admin/autores/editar/{id}")]
        public string Editar(int id)
        {
            return "editar autor";
        }

        [HttpPost]
        [Route("admin/autores/remover/{id}")]
        public string Remover(int id)
        {
            return "remover autor";
        }
    }
}
