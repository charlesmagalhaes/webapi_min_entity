namespace webapi_min_entity.ModelViews;

public struct PedidoCliente
{
     public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public double ValorTotal { get; set; }
    public string NomeProduto { get; set; }
    public int QuantidadeVendidaProduto { get; set; }
    public double ValorVendidaProduto { get; set; }
    
}