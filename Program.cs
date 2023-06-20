using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi_min_entity.Contexto;
using webapi_min_entity.Entidades;
using webapi_min_entity.ModelViews;
using webapi_min_entity.Request;

var contexto = new BancoDeDadosContexto();
/*contexto.Clientes.Add(new Cliente{
    Nome = "Douglas Dog", 
    Telefone = "(31)99944-5454"
});

contexto.SaveChanges();*/

//8var clientes = contexto.Clientes.ToList();*/

/*var cliente = contexto.Clientes.First();
cliente.Nome = "Douglas Hits";
contexto.Update(cliente);
contexto.SaveChanges();*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Clientes", () =>
{
    var clientes = contexto.Clientes.ToList();
   return clientes;
})
.WithName("ObterClientes")
.WithOpenApi();

app.MapGet("/Clientes/{matricula}", (int id) =>
{
    var cliente = contexto.Clientes.Find(id);
    return cliente;

})
.WithName("ObterCliente")
.WithOpenApi();


app.MapPost("/Clientes", ([FromBody] ClienteRequest cliente) =>
{
    contexto
    .Clientes
    .Add(new Cliente
                {
                 Nome = cliente.Nome, 
                 Telefone = cliente.Telefone,
                 Observacao = cliente.Observacao
                });
    contexto.SaveChanges();
})
.WithName("CadastrarCliente")
.WithOpenApi();

app.MapPut("/Clientes/{matricula}", (int id, Cliente cliente) =>
{
    var clienteChange = contexto.Clientes.Find(id);
    if (clienteChange != null)
    {
        if (!string.IsNullOrEmpty(cliente.Nome))
        {
            clienteChange.Nome = cliente.Nome;
        }

        if (!string.IsNullOrEmpty(cliente.Telefone))
        {
            clienteChange.Telefone = cliente.Telefone;
        }

            if (!string.IsNullOrEmpty(cliente.Observacao))
        {
            clienteChange.Observacao = cliente.Observacao;
        }

        contexto.Update(clienteChange);
        contexto.SaveChanges();

        return "Cliente atualizado com sucesso.";
    }
    else
    {
        return "Cliente não encontrado.";
    }
})
.WithName("AtualizarCliente")
.WithOpenApi();


app.MapDelete("/Clientes/{matricula}", (int id) =>
{
    var cliente = contexto.Clientes.Find(id);
    if (cliente != null)
    {
        contexto.Clientes.Remove(cliente);
        contexto.SaveChanges();
        return "Cliente excluído com sucesso.";
    }
    else
    {
        return "Cliente não encontrado.";
    }
})
.WithName("DeletarCliente")
.WithOpenApi();

app.MapGet("/Compras/Pedidos-Clientes", ([FromQuery] int page) =>
{
    var totalPage = 4;
    if(page == null || page < 1) page = 1;
    int offset = ((int)page - 1) * totalPage;
    
    var clientesLista = contexto.Pedidos.Include( p => p.Cliente).Select( p => new PedidoCliente {
        Nome = p.Cliente.Nome,
        Telefone = p.Cliente.Telefone,
        ValorTotal = p.ValorTotal
    });

    var clientesPaginado = clientesLista.Skip(offset).Take(totalPage).ToList();

   return new RegistroPaginado<PedidoCliente> {
        TotalPorPagina = totalPage,
        PaginaAtual = (int)page,
        Registros = clientesPaginado,
        TotalRegistros = clientesLista.Count()

   };
})
.WithName("/Compras/PedidosClientes")
.WithOpenApi();

app.Run();