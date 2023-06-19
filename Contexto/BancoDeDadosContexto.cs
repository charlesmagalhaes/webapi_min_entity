using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using webapi_min_entity.Entidades;

namespace webapi_min_entity.Contexto
{
    public class BancoDeDadosContexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("conexao");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<Fornecedor> Fornecedores { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;
        public DbSet<PedidoProduto> PedidosProdutos { get; set; } = default!;
         public DbSet<Produto> Produtos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(ConfigureCliente);
        }

        private void ConfigureCliente(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100).HasColumnName("cli_nome");
            builder.Property(c => c.Telefone).IsRequired().HasMaxLength(20).HasColumnName("cli_telefone");
            builder.Property(c => c.Observacao).HasColumnType("text").HasColumnName("cli_observacao");
        }

        private void ConfigureProduto(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnName("Id");
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100).HasColumnName("Nome");
            builder.Property(c => c.Valor).IsRequired().HasMaxLength(20).HasColumnName("Valor");
            builder.Property(c => c.Descricao).HasColumnType("text").HasColumnName("Descricao");
        }

        private void ConfigurePedido(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnName("Id");
        }
    }
}
