namespace TesteDesenvolvimento.Data.Models
{
    public partial class Cliente
    {
        public int ClienteId { get; set; }
        public int PedidoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
