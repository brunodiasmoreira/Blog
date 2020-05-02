using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao
{
    public class RevisaoOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public RevisaoOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<RevisaoEntity> ObterRevisoes()
        {
            return _databaseContext.Revisoes.ToList();
        }

        public RevisaoEntity ObterAutorPorId(int idRevisao)
        {
            var revisao = _databaseContext.Revisoes.Find(idRevisao);

            return revisao;
        }
        public RevisaoEntity CriarRevisao(RevisaoEntity novaRevisao)
        {
            _databaseContext.Revisoes.Add(novaRevisao);
            _databaseContext.SaveChanges();

            return novaRevisao;
        }

        public RevisaoEntity EditarRevisao(int id, string texto)
        {
            var revisao = _databaseContext.Revisoes.Find(id);

            if (revisao == null)
            {
                throw new Exception("Revisão não encontrada!");
            }

            revisao.Texto = texto;
            _databaseContext.SaveChanges();

            return revisao;
        }

        public bool RemoverRevisao(int id)
        {
            var revisao = _databaseContext.Revisoes.Find(id);

            if (revisao == null)
            {
                throw new Exception("Revisão não encontrada!");
            }

            _databaseContext.Revisoes.Remove(revisao);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
