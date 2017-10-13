using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Dominio.Entidad
{
    [Table("tiposdebancos")]
    public class TipoBanco
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }





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





        public virtual IEnumerable<Banco> Bancos { get; set; }
    }
}
