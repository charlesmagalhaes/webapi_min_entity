using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_min_entity.Entidades;

public record PedidoProduto
{
    public int Id {get;set;}

    public int PedidoID {get;set;}

    public Pedido Pedido {get;set;} = default!;
    public int ProdutoID {get;set;}

    public Produto Produto {get;set;} = default!;
    public int Quantidade { get; set; }
    public double Valor { get; set; }
    
}