using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_min_entity.Entidades;

public record Produto
{
    public int Id {get;set;}

    public string Nome {get;set;} = default!;

    public string Descricao {get;set;} = default!;

    public double Valor { get; set; } = default!;
    
}