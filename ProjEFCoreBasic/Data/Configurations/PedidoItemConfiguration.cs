using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjEFCoreBasic.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> b)
        {
            b.HasKey(p => p.Id);
            //'HasDefaultValue' define valor 1 caso eu não defina a quantidade na criação do objeto
            b.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();
            b.Property(p => p.Valor).HasDefaultValue(0).IsRequired();
            b.Property(p => p.Desconto).HasDefaultValue(0).IsRequired();
        }
    }
}
