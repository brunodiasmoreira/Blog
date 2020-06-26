using System.ComponentModel.DataAnnotations;
using Blog.Models.Blog.Etiqueta;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemEtiquetaEntity
    {
        [Key]
        public int Id { get; set; }

        public PostagemEntity Postagem { get; set; }

        public EtiquetaEntity Etiqueta { get; set; }
    }
}