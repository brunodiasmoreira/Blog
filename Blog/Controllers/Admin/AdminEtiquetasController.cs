using Blog.Models.Blog.Etiqueta;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers.Admin
{
    public class AdminEtiquetasController : Controller
    {
        private readonly EtiquetaOrmService _etiquetaOrmService;
        public AdminEtiquetasController(
            EtiquetaOrmService etiquetaOrmService
        )
        {
            _etiquetaOrmService = etiquetaOrmService;
        }

        [HttpGet]
        [Route("admin/etiquetas")]
        [Route("admin/etiquetas/listar")]
        public string Listar()
        {
            return "listar etiquetas";
        }
        [HttpPost]
        [Route("admin/etiquetas/criar")]
        public string Criar()
        {
            return "criar etiqueta";
        }
        [HttpPost]
        [Route("admin/etiquetas/editar/{id}")]
        public string Editar(int id)
        {
            return "editar etiqueta";
        }
        [HttpPost]
        [Route("admin/etiquetas/remover/{id}")]
        public string Remover(int id)
        {
            return "remover etiqueta";
        }
    }
}
