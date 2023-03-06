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
                b.HasKey(p => p.Id);
                b.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
                b.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
                b.Property(p => p.Valor).IsRequired();
                //'HasConversion' define que essa coluna será do tipo 'string' e grava o nome do Enum ao invés do número dele
                b.Property(p => p.TipoProduto).HasConversion<string>();

                //não precisa preencher a multiplicidade, pois o ICollection dele não foi adicionado
            });

            modelBuilder.Entity<Pedido>(b =>
            {
                b.HasKey(p => p.Id);
                //'GETDATE' preenche com a data atual na criação do objeto
                b.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                b.Property(p => p.Status).HasConversion<string>();//grava o nome do Enum
                b.Property(p => p.TipoFrete).HasConversion<int>();//grava o número do Enum
                b.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

                //1 Pedido x N PedidoItem(Itens)
                b.HasMany(p => p.Itens)
                    .WithOne(p => p.Pedido)
                    .OnDelete(DeleteBehavior.Cascade);//Ao deletar um Pedido, deletará todos os 'PedidoItem' dele em cascata
                //.OnDelete(DeleteBehavior.SetNull); -> Os 'ItemPedido' não são removidos do DB ao remover um 'pedido', porém
                //é necessário setar como NULL o 'PedidoId' do obejeto 'PedidoItem'
            });

            modelBuilder.Entity<PedidoItem>(b =>
            {
                b.HasKey(p => p.Id);
                //define valor 1 caso eu não defina a quantidade na criação do objeto
                b.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();
                b.Property(p => p.Valor).HasDefaultValue(0).IsRequired();
                b.Property(p => p.Desconto).HasDefaultValue(0).IsRequired();
            });

        }
    }
}
