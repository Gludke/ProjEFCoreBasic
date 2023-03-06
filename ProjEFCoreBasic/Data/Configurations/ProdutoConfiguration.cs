using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjEFCoreBasic.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> b)
        {
            b.HasKey(p => p.Id);
            b.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
            b.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
            b.Property(p => p.Valor).IsRequired();
            //'HasConversion' define que essa coluna será do tipo 'string' e grava o nome do Enum ao invés do número dele
            b.Property(p => p.TipoProduto).HasConversion<string>();

            //não precisa preencher a multiplicidade, pois o ICollection dele não foi adicionado
        }
    }
}
