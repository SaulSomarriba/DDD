
using DDD.Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.Data.Contexto
{
    public class ModeloContexto: DbContext
    {
        public ModeloContexto(): base("DefaultConexion") { }

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<TipoBanco> TipoBancos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties().Where(p=>p.Name == p.ReflectedType.Name + "Id")
                    .Configure(p=>p.IsKey());

            modelBuilder.Properties<string>().Configure(p=> p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p=>p.HasMaxLength(250));




        }


        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry =>entry.GetType().GetProperty("DataCreation") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCreation").CurrentValue = System.DateTime.Now.Date;
                }
            }

            return base.SaveChanges();
        }
    }

    
}
