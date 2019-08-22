using EP.CursoMVC.Domain.Models;
using System.Data.Entity;
using System.Linq;
using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using EP.CursoMVC.Infra.Data.EntityConfig;

namespace EP.CursoMVC.Infra.Data.Context
{
    public class CursoMVCContext : DbContext
    {
        public CursoMVCContext() : base("DefaultConnection") //Conection String
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }
        // ChangeTracker.Entries, mapeia as mudancas das entidades
        // Where - Onde a minha entrada...
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;

            }

            return base.SaveChanges();
        }
    }
}
