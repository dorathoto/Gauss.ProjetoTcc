using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gauss.ProjetoTcc.Models
{
    public class Noticia
    {
        public Guid NoticiaId { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(400, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Conteudo { get; set; }

        public DateTime DataPublicacao { get; set; }

        [NotMapped]
        public IFormFile ArquivoImagem { get; set; }

        public bool NoticiaPrincipal { get; set; }

        public Guid UsuarioId { get; set; }
        [ForeignKey(nameof(UsuarioId))]
        public virtual Usuario Usuario { get; set; }

        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
