using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Gauss.ProjetoTcc.Models
{
    public class Usuario : IdentityUser<Guid>
    {
        [StringLength(128)]
        public string Nome { get; set; }

        [StringLength(128)]
        public string Sobrenome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Noticia> Noticias { get; set; }
    }
}
