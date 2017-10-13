using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDD.MVC.ViewModels
{
    public class TipoBancoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se requiere el Nombre del Tipo de Banco")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]

        [Display(Name = "Tipo de Banco")]
        public string Name { get; set; }





        [Display(Name = "Activo")]
        public bool Active { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreation { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateModification { get; set; }

        public virtual IEnumerable<BancoViewModel> Bancos { get; set; }
    }
}