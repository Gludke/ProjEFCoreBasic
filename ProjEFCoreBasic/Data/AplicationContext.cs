using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace ProjEFCoreBasic.Data
{
    public class AplicationContext : DbContext
    {
        //Criando as tabelas do DB
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        //Configura o BD da aplicação
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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
