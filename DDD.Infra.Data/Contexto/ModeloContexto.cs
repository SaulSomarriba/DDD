using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Dominio.Entidad;
using DDD.Infra.Data.EntityConfig;

namespace DDD.Infra.Data.Contexto
{
    public class ModeloContexto: DbContext
    {

        public ModeloContexto(): base("DefaultConexion")
        {

        }


        public DbSet<Banco> Banco { get; set; }
        public DbSet<TipoBanco> TipoBancos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Modifica el modelo para eliminar la eliminacion en cascada
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p=>p.IsKey());


            modelBuilder.Properties<string>()
                .Configure(p=>p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(250));


            #region EntityConfiguration

                modelBuilder.Configurations.Add(new BancoConfiguration());
                modelBuilder.Configurations.Add(new TipoBancoConfiguration());

            #endregion 
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateCreation") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateCreation").CurrentValue = System.DateTime.Now.Date;
                }

            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateModification") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateModification").CurrentValue = System.DateTime.Now.Date;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateModification").CurrentValue = System.DateTime.Now.Date;
                }
            }
            return base.SaveChanges();
        }
    }
}
