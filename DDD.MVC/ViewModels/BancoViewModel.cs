using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDD.MVC.ViewModels
{
    public class BancoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se requiere la abreviatura del Banco")]
        [MaxLength(10, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [Display(Name = "Siglas")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Por favor ingrese una Abreviatura  Valida")]
        public string ACRONYMS { get; set; }

        [Required(ErrorMessage = "Se requiere el Nombre del Banco")]
        [MaxLength(30, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [Display(Name = "Nombre")]
        //[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Por favor ingrese un Nombre Valido")]
        public string Name { get; set; }

        [Display(Name = "Tipo de Banco")]
        [ForeignKey("TipoBancos")]
        public int TipoBancoId { get; set; }




        [ScaffoldColumn(true)]
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




        public virtual TipoBancoViewModel TipoBancos { get; set; }
    }
}