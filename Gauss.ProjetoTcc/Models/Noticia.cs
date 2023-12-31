﻿using Gauss.ProjetoTcc.Models.Enums;
using Gauss.ProjetoTcc.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gauss.ProjetoTcc.Models
{
    public class Noticia : IStatusModificacao
    {
        public Guid NoticiaId { get; set; }

        public Guid UsuarioId { get; set; }
        public Guid CategoriaId { get; set; }



        public TipoNoticia TipoNoticia { get; set; }

        [Required]
        [MaxLength(70, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(4000, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Conteudo { get; set; }

        #region Interface
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Excluído")]
        public bool Excluido { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data Excluído")]
        public DateTime? DataExcluido { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data Últ. Modificação")]
        public DateTime? DataUltimaModificacao { get; set; }
        #endregion





        [ForeignKey(nameof(UsuarioId))]
        public virtual Usuario? Usuario { get; set; }
    
        public virtual Categoria? Categoria { get; set; }
    }
}
