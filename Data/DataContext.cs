using TrabalhoPooBanco.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace Data.Context
{
    public class DataContext : DbContext
    {
        public string DbPath { get; }

        public DbSet<Cliente> Clientes { get; set; }
        public Cliente ObterCliente(int clienteId)
        {
            return Clientes.Find(clienteId);
        }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Saque> Saques { get; set; }
        public DbSet<Deposito> Depositos { get; set; }

        public DbSet<Transferencia> Transferencias { get; set; }


        public DataContext()
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = Path.Combine(path, "PooBancoApDois.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(c => c.Id);

                // Mapeamento das propriedades
                entity.Property(c => c.Id).IsRequired();
                entity.Property(c => c.CPF).IsRequired().HasMaxLength(11);

                modelBuilder.Entity<Conta>()
                .HasKey(c => c.Id);


                modelBuilder.Entity<Conta>(entity =>
                {
                    entity.ToTable("Contas");
                    entity.HasKey(c => c.Id);

                    // Mapeamento das propriedades
                    entity.Property(c => c.Id).IsRequired();
                });
                modelBuilder.Entity<Deposito>()
            .Property(d => d.IdDeposito)
            .HasColumnName("id"); // Especifica o nome da coluna do banco de dados

                // Outras configurações do modelo...

                base.OnModelCreating(modelBuilder);


                {
                    modelBuilder.Entity<Saque>();
                    modelBuilder.Entity<Deposito>();
                    modelBuilder.Entity<Transferencia>();
                }

                modelBuilder.Entity<Resultado>(entity =>
                {
                    entity.ToTable("Resultados");
                    entity.HasKey(r => r.Id);

                    // Configurações adicionais da entidade Resultado, se houver.
                });

                modelBuilder.Entity<Transacao>(entity =>
                {
                    entity.ToTable("Transacoes");
                    entity.HasKey(t => t.Id);

                    // Configurações adicionais da entidade Transacao, se houver.
                });


            });
        }

    }
}



