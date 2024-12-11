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

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.IncludeFields = true;
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

app.MapGet("/clientes", Ok<ClientData[]> (ClientsList data) => TypedResults.Ok(data.GetClients()));
app.MapGet(
    "/clientes/{id}",
    Results<Ok<ClientData>, NotFound> (int id, ClientsList data) =>
        data.GetClient(id) is ClientData client ? TypedResults.Ok(client) : TypedResults.NotFound()
);
app.MapPost(
    "/clientes",
    Ok<ClientData> (ClientEntry client, ClientsList data) => TypedResults.Ok(data.AddClient(client))
);
app.MapPut(
    "/clientes",
    Results<Ok<ClientData>, NotFound> (ClientData client, ClientsList data) =>
        data.EditClient(client.Id, client.FirstName, client.LastName, client.Address)
            is ClientData updatedClient
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
