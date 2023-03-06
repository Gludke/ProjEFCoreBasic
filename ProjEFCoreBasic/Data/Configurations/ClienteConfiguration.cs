using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjEFCoreBasic.Data.Configurations
{
    //interface que permite separar as configuração da 'FluentAPI' de cada classe do modelo
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> b)
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
        }
    }
}
