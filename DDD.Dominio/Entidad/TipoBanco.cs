using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Dominio.Entidad
{
    [Table("TipodeBancos")]
    public class TipoBanco
    { 
        [Key]

        public int Id { get; set; }

        //[Required(ErrorMessage = "Se requiere la {0}")]
        //[Display(Name = "Abreviación")]
        //public string Acronym { get; set; }

        [Required(ErrorMessage = "Se requiere el {0}")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }


        //Campos de control
        [Display(Name = "Activo")]
        public bool Active { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DateCreation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DateModification { get; set; }


        public virtual IEnumerable<Banco> Bancos { get; set; }

    }
}
