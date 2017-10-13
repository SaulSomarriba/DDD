using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Dominio.Entidad;

namespace DDD.Infra.Data.EntityConfig
{
    class BancoConfiguration : EntityTypeConfiguration<Banco>
    {
        public BancoConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.ACRONYMS)
                .IsRequired()
                .HasMaxLength(10);

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(30);

            Property(t => t.TipoBancoId)
                .IsRequired()
                .HasColumnName("TipoBancoId");
        }



    }
}
