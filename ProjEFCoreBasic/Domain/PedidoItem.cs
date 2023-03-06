using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEFCore.Domain
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Desconto { get; set; }
    }
}