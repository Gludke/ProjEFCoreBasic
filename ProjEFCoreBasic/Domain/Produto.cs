using ProjEFCoreBasic.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEFCore.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }
    }
}