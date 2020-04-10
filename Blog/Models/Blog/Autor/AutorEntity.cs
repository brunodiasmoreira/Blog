using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Blog.Autor
{
    public class AutorEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        [Required]
        public string Nome { get; set; }
    }
}
