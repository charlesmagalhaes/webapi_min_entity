namespace webapi_min_entity.Request;

public record ClienteRequest
{
    public string Nome { get; set; } = default!;

    public string Telefone { get; set; } = default!;

      public string Observacao { get; set; } = default!;
    
}