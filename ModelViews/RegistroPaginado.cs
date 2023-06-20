namespace webapi_min_entity.ModelViews;

public struct RegistroPaginado<T>
{
    public int TotalRegistros { get; set; }
    public int PaginaAtual { get; set; }
    public int TotalPorPagina { get; set; }
    public List<T> Registros {get;set;}
    
}