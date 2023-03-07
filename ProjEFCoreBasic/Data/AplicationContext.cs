using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProjEFCoreBasic.Data
{
    public class AplicationContext : DbContext
    {
        //Gera o log das operações no DB. Necessário o package 'Microsoft.Extensions.Logging.Console'
        //Adiciona o log no console da app
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(l => l.AddConsole());

        //Criando as tabelas do DB
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        //Configura o BD da aplicação
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Registra o log das operaçoes do EFCore no nosso logger
            optionsBuilder.UseLoggerFactory(_logger);
            //Mostra os dados sensíveis das operações do EFCore
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DbEFCoreBasic;Trusted_Connection=True;");
        }

        //Configura os modelos de dados do DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //busca por todas as classes que implementam a interface "IEntityTypeConfiguration<T>" na mesma 'Assembly' do DbContext.
            //"ApplyConfigurationsFromAssembly" é usado para aplicar as configurações de mapeamento de todas as entidades
            //do modelo definido em classes de configuração separadas em uma única chamada de método.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicationContext).Assembly);
        }
    }
}
