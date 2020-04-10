using Blog.Models.Blog.Postagem;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.Models.Blog.Categoria;

namespace Blog.Models.Blog.Etiqueta
{
    public class EtiquetaEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        [Required]
        public string Nome { get; set; }

        [Required]
        public CategoriaEntity Categoria { get; set; }

        public List<PostagemEtiquetaEntity> PostagensEtiquetas { get; set; }

        public EtiquetaEntity()
        {
            PostagensEtiquetas = new List<PostagemEtiquetaEntity>();
        }
    }
}
