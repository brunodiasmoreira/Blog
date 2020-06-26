using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;

namespace Blog.Models.Blog.Categoria
{
    public class CategoriaEntity
    {
        [Key] public int Id { get; set; }

        [MaxLength(128)] [Required] public string Nome { get; set; }

        public ICollection<PostagemEntity> Postagens { get; set; }

        public ICollection<EtiquetaEntity> Etiquetas { get; set; }


        public CategoriaEntity()
        {
            Postagens = new List<PostagemEntity>();
            Etiquetas = new List<EtiquetaEntity>();
        }
    }
}