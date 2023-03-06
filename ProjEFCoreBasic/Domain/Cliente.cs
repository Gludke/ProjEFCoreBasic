namespace CursoEFCore.Domain
{
    //[Table("Clientes")] - define o nome da table do DB
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}