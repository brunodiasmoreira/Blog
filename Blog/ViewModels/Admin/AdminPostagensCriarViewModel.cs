using System.Collections.Generic;

namespace Blog.ViewModels.Admin
{
    public class AdminPostagensCriarViewModel : ViewModelAreaAdministrativa
    {
        public string Erro { get; set; }

        public ICollection<CategoriaAdminPostagens> Categorias { get; set; }

        public ICollection<AutorAdminPostagens> Autores { get; set; }



        public AdminPostagensCriarViewModel()
        {
            TituloPagina = "Criar nova Postagem";
            Categorias = new List<CategoriaAdminPostagens>();
            Autores = new List<AutorAdminPostagens>();

        }

    }
    public class CategoriaAdminPostagens
    {
        public int IdCategorias { get; set; }
        public string NomeCategorias { get; set; }
    }
    public class AutorAdminPostagens
    {
        public int IdAutores { get; set; }
        public string NomeAutores { get; set; }
    }
    public class EtiquetaAdminPostagens
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}