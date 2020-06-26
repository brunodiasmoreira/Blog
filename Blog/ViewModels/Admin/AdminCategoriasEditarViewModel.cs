using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminCategoriasEditarViewModel : ViewModelAreaAdministrativa
    {
        public int IdCategoria { get; set; }

        public string NomeCategoria { get; set; }
        public string Erro { get; set; }
        public AdminCategoriasEditarViewModel()
        {
            TituloPagina = "Editar Categoria: ";

        }
    }
}
