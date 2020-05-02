using Blog.Models.Blog.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Etiqueta
{
    public class EtiquetaOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public EtiquetaOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public List<EtiquetaEntity> ObterEtiquetas()
        {
            return _databaseContext.Etiquetas.ToList();
        }
        public EtiquetaEntity ObterEtiquetaPorId(int idCategoria)
        {
            var etiqueta = _databaseContext.Etiquetas.Find(idCategoria);

            return etiqueta;
        }
        public List<EtiquetaEntity> PesquisarEtiquetaPorNome(string nomeEtiquetas)
        {
            return _databaseContext.Etiquetas.Where(c => c.Nome.Contains(nomeEtiquetas)).ToList();
        }
        public EtiquetaEntity CriarEtiqueta(string nome, CategoriaEntity categoria)
        {
            var novaEtiqueta = new EtiquetaEntity { Nome = nome, Categoria = categoria };
            _databaseContext.Etiquetas.Add(novaEtiqueta);
            _databaseContext.SaveChanges();

            return novaEtiqueta;
        }
        public EtiquetaEntity EditarEtiqueta(int id, string nome)
        {
            var etiqueta = _databaseContext.Etiquetas.Find(id);

            if (etiqueta == null)
            {
                throw new Exception("Etiqueta não encontrada!");
            }

            etiqueta.Nome = nome;
            _databaseContext.SaveChanges();

            return etiqueta;
        }
        public bool RemoverEtiqueta(int id)
        {
            var etiqueta = _databaseContext.Etiquetas.Find(id);

            if (etiqueta == null)
            {
                throw new Exception("Etiqueta não encontrada!");
            }

            _databaseContext.Etiquetas.Remove(etiqueta);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
