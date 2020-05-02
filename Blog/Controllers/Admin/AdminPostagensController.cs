using Blog.Models.Blog.Postagem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers.Admin
{
    public class AdminPostagensController : Controller
    {
        private readonly PostagemOrmService _postagemOrmService;
        public AdminPostagensController(
            PostagemOrmService postagemOrmService
        )
        {
            _postagemOrmService = postagemOrmService;
        }

        [HttpGet]
        [Route("admin/postagens")]
        [Route("admin/postagens/listar")]
        public string Listar()
        {
            return "listar postagens";
        }
        [HttpPost]
        [Route("admin/postagens/criar")]
        public string Criar()
        {
            return "criar postagem";
        }
        [HttpPost]
        [Route("admin/postagens/editar/{id}")]
        public string Editar(int id)
        {
            return "editar postagen";
        }
        [HttpPost]
        [Route("admin/postagens/remover/{id}")]
        public string Remover(int id)
        {
            return "remover postagen";
        }
    }
}
