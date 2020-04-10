using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Autor
{
    public class AutorOrmService
    {
        private readonly DatabaseContext db;

        public AutorOrmService(DatabaseContext db)
        {
            this.db = db;
        }

        public List<AutorEntity> GetAll()
        {
            return this.db.Autores.ToList();
        }
    }
}
