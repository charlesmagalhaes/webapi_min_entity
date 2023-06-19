using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_min_entity.Entidades;

public record Pedido
{
    public int Id {get;set;}
    public int ClienteID {get;set;}
    public Cliente Cliente {get;set;} = default!;

    public double ValorTotal {get;set;} 

    public DateTime Data {get;set;}

    
}