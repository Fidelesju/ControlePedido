namespace TesteDesenvolvimento.Data.ResponseModels
{
    public partial class PedidoResponseModel
    {
        public int PedidoId { get; set; }
        public int ItemId { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QuantidadeItens { get; set; }
        public List<string>  Itens { get; set; }
    }
}
