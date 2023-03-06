using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace ProjEFCoreBasic.Data
{
    public class AppContext : DbContext
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
            modelBuilder.Entity<Cliente>(b =>
            {
                //b.ToTable("Clientes");
                b.HasKey(p => p.Id);
                b.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();//'VARCHAR' tamanho variável
                b.Property(p => p.Telefone).HasColumnType("CHAR(11)");//tipo 'CHAR' define o tamanho do campo como fixo
                b.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired();
                b.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
                b.Property(p => p.Cidade).HasMaxLength(60).IsRequired();
                //Cria a coluna do telefone como índice: serve para melhorar muito o desempenho dessa coluna como chave de consultas 
                b.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone");
            });

            modelBuilder.Entity<Produto>(b =>
            {
                //b.ToTable("Produtos");
                b.HasKey(p => p.Id);
                b.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
                b.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
                b.Property(p => p.Valor).IsRequired();
                b.Property(p => p.TipoProduto).HasConversion<string>();
            });
        }
    }
}
