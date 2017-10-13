using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Dominio.Entidad
{
    [Table("bancos")]
    public class Banco
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se requiere la abreviatura del Banco")]
        [Display(Name = "Abreviatura")]
        public string ACRONYMS { get; set; }

        [Required(ErrorMessage = "Se requiere el nombre del Banco")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar el Tipo de Banco")]
        [Display(Name = "Tipo de Banco")]
        public int TipoBancoId { get; set; }





        [Display(Name = "Activo")]
        [Required]
        public bool Active { get; set; }
        
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateCreation { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateModification { get; set; }





        [ForeignKey("TipoBancoId")]
        public virtual TipoBanco TipoBancos { get; set; }
    }

}
