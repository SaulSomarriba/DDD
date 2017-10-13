using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Dominio.Entidad;

namespace DDD.Infra.Data.EntityConfig
{
    class TipoBancoConfiguration : EntityTypeConfiguration<TipoBanco>
    {

        public TipoBancoConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
