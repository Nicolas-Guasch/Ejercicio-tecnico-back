using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clients API", Description = "Manage clients database", Version = "v1" });
});

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


ClientsList data = new ClientsList();

app.MapGet("/clientes", () => data.GetClients());
app.MapGet("/clientes/{id}", (int id) => data.GetClient(id));
app.MapPost("/clientes", (ClientEntry client) => data.AddClient(client));
app.MapPut("/clientes", (ClientData client) => data.EditClient(client.Id, client.FirstName, client.LastName, client.Address));
app.MapDelete("/clientes/{id}", (int id) => data.DeleteClient(id));


app.Run();


