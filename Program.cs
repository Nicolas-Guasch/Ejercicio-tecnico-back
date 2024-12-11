using System.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "Clients API",
            Description = "Manage clients database",
            Version = "v1",
        }
    );
});

builder.Services.AddSingleton<ClientsList>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clients API V1");
    });
}

app.UseHttpsRedirection();

app.MapGet("/clientes", Ok<Client[]> (ClientsList data) => TypedResults.Ok(data.GetClients()));
app.MapGet(
    "/clientes/{id}",
    Results<Ok<Client>, NotFound> (int id, ClientsList data) =>
        data.GetClient(id) is Client client ? TypedResults.Ok(client) : TypedResults.NotFound()
);

//Post recibe ClientEntry con los datos del nuevo cliente excepto el id. El id se genera en el back para garantizar unicidad.
//Alternativamente, se podría recibir un ID, y responder con error si ya existe en la lista.
app.MapPost(
    "/clientes",
    Ok<Client> (ClientEntry client, ClientsList data) => TypedResults.Ok(data.AddClient(client))
);
app.MapPut(
    "/clientes",
    Results<Ok<Client>, NotFound> (Client client, ClientsList data) =>
        data.EditClient(client.Id, client.FirstName, client.LastName, client.Address)
            is Client updatedClient
            ? TypedResults.Ok(updatedClient)
            : TypedResults.NotFound()
);
app.MapDelete(
    "/clientes/{id}",
    Results<Ok, NotFound> (int id, ClientsList data) =>
        data.DeleteClient(id) ? TypedResults.Ok() : TypedResults.NotFound()
);

app.Use(
    async (context, next) =>
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        await next.Invoke();
        stopwatch.Stop();
        Console.WriteLine($"Request processed in {stopwatch.ElapsedMilliseconds} milliseconds.");
    }
);

app.Run();
