using Blog.Models.Blog.Postagem;
using Blog.RequestModels.AdminPostagens;
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
        public IActionResult Listar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detalhar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            ViewBag.erro = TempData["erro-msg"];
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Criar(AdminPostagemCriarRequestModel request)
        {
            var titulo = request.Titulo;
            var descricao = request.Descricao;
            var autor = request.Autor;
            var categoria = request.Categoria;
            var dataPostagem = request.DataPostagem;

            try
            {
                _postagemOrmService.CriarPostagem(titulo, descricao, autor, categoria, dataPostagem);
            }
            catch (Exception exception)
            {
                TempData["error-msg"] = exception.Message;
                return RedirectToAction("Criar");
            }
            return RedirectToAction("Listar");
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewBag.id = id;
            ViewBag.erro = TempData["erro-msg"];

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Editar(AdminPostagemEditarRequestModel request)
        {
            var id = request.Id;
            var titulo = request.Titulo;
            var descricao = request.Descricao;
            var autor = request.Autor;
            var categoria = request.Categoria;
            var dataPostagem = request.DataPostagem;

            try
            {
                _postagemOrmService.EditarPostagem(id, titulo, descricao, autor, categoria, dataPostagem);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Editar", new { id = id });
            }
            return RedirectToAction("Listar");
        }
        [HttpGet]
        public IActionResult Remover(int id)
        {
            ViewBag.id = id;
            ViewBag.erro = TempData["erro-msg"];
            return View();

        }
        [HttpPost]
        public RedirectToActionResult Remover(AdminPostagemRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _postagemOrmService.RemoverPostagem(id);
            }
            catch (Exception exception)
            {
                TempData["Erro-msg"] = exception.Message;
                return RedirectToAction("Remover", new { id = id });
            }
            return RedirectToAction("Listar");
        }
    }
}
