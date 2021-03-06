﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Postagem.Revisao;
using Blog.ViewModels.Home;
using Blog.Models.Blog.Autor;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoriaOrmService _categoriaOrmService;
        private readonly PostagemOrmService _postagemOrmService;

        public HomeController(
            ILogger<HomeController> logger,
            CategoriaOrmService categoriaOrmService,
            PostagemOrmService postagemOrmService
        )
        {
            _logger = logger;
            _categoriaOrmService = categoriaOrmService;
            _postagemOrmService = postagemOrmService;
        }

        public IActionResult Index()
        {
            // Instanciar a ViewModel
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.TituloPagina = "Página Home";

            // Alimentar a lista de postagens que serão exibidas na view
            List<PostagemEntity> listaPostagens = _postagemOrmService.ObterPostagens();

            foreach (PostagemEntity postagem in listaPostagens)
            {
                PostagemHomeIndex postagemHomeIndex = new PostagemHomeIndex();
                postagemHomeIndex.Titulo = postagem.Titulo;
                postagemHomeIndex.Descricao = postagem.Descricao;
                postagemHomeIndex.Categoria = postagem.Categoria.Nome;
                postagemHomeIndex.NumeroComentarios = postagem.Comentarios.Count.ToString();
                postagemHomeIndex.PostagemId = postagem.Id.ToString();

                // Obter última revisão
                RevisaoEntity ultimaRevisao = postagem.Revisoes.OrderByDescending(o => o.DataCriacao).FirstOrDefault();
                if (ultimaRevisao != null)
                {
                    postagemHomeIndex.Data = ultimaRevisao.DataCriacao.ToLongDateString();
                }

                model.Postagens.Add(postagemHomeIndex);
            }

            // Alimentar a lista de categorias que serão exibidas na view
            List<CategoriaEntity> listaCategorias = _categoriaOrmService.ObterCategorias();

            foreach (CategoriaEntity categoria in listaCategorias)
            {
                CategoriaHomeIndex categoriaHomeIndex = new CategoriaHomeIndex();
                categoriaHomeIndex.Nome = categoria.Nome;
                categoriaHomeIndex.CategoriaId = categoria.Id.ToString();

                model.Categorias.Add(categoriaHomeIndex);

                // Alimentar a lista de etiquetas que serão exibidas na view, a partir das etiquetas da categoria
                foreach (EtiquetaEntity etiqueta in categoria.Etiquetas)
                {
                    EtiquetaHomeIndex etiquetaHomeIndex = new EtiquetaHomeIndex();
                    etiquetaHomeIndex.Nome = etiqueta.Nome;
                    etiquetaHomeIndex.EtiquetaId = etiqueta.Id.ToString();

                    model.Etiquetas.Add(etiquetaHomeIndex);
                }
            }

            // Alimentar a lista de postagens populares que serão exibidas na view
            // TODO Obter lista de postagens populares
            List<PostagemEntity> listaPostagensPopulares = _postagemOrmService.ObterPostagensPopulares();
            int count = 0;
            foreach (PostagemEntity postagem in listaPostagensPopulares)
            {
                PostagemPopularHomeIndex postagemPopularHomeIndex = new PostagemPopularHomeIndex();
                postagemPopularHomeIndex.Titulo = postagem.Titulo;
                postagemPopularHomeIndex.Categoria = postagem.Categoria.Nome;
                postagemPopularHomeIndex.PostagemId = postagem.Id.ToString();

                count++;

                if (count <= 4)
                {
                    model.PostagensPopulares.Add(postagemPopularHomeIndex);
                }
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}