using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Dominio.Entidad
{
    [Table("Bancos")]
    public class Banco
    {
        Banco()
        {
            Active = true;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se requiere la {0}")]
        [Display(Name = "Abreviación")]
        public string Acronym { get; set; }

        [Required(ErrorMessage = "Se requiere el {0}")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Se requiero seleccionar el tipo de banco")]
        [Display(Name = "Tipo de Banco")]
        public int TipoBancoId { get; set; }


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

        [ForeignKey("TipoBancoId")]
        public virtual TipoBanco TipoBancos { get; set; }
        
}
}
