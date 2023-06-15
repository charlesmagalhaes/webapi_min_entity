using Microsoft.EntityFrameworkCore;
using webapi_min_entity.Entidades;

namespace webapi_min_entity.Contexto;

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
    
}