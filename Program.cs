using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi_min_entity.Contexto;
using webapi_min_entity.Entidades;
using webapi_min_entity.ModelViews;
using webapi_min_entity.Request;
using webapi_min_entity.Routes;

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

//app.UseHttpsRedirection();
new ClienteService(app).Register();
new FornecedorService(app).Register();
new PedidoService(app).Register();
new ProdutoService(app).Register();
new PedidoProdutoService(app).Register();


app.Run();