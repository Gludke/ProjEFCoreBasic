using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjEFCoreBasic.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> b)
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
                .OnDelete(DeleteBehavior.Cascade);
            //.OnDelete(DeleteBehavior.SetNull); -> Os 'ItemPedido' não são removidos do DB ao remover um 'pedido', porém
            //é necessário setar como NULL o 'PedidoId' do obejeto 'PedidoItem'
        }
    }
}
