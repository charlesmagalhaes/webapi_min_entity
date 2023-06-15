using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi_min_entity.Contexto;
using webapi_min_entity.Entidades;

var contexto = new BancoDeDadosContexto();
/*contexto.Clientes.Add(new Cliente{
    Nome = "Douglas Dog", 
    Telefone = "(31)99944-5454"
});

contexto.SaveChanges();*/

var clientes = contexto.Clientes.ToList();

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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/Clientes", () =>
{
    var clientes = contexto.Clientes.ToList();
   return clientes;
})
.WithName("Home")
.WithOpenApi();

app.MapPost("/Clientes", ([FromBody] Cliente cliente) =>
{
    contexto.Clientes.Add(new Cliente{
                                        Nome = cliente.Nome, 
                                        Telefone = cliente.Telefone
                                     });
    contexto.SaveChanges();
})
.WithName("CadastrarAluno")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
