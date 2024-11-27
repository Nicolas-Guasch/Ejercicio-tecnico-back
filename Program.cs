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
app.MapPost("/clientes", (ClientData client) => data.AddClient(client));
app.MapPut("/clientes", (Client client) => data.EditClient(client.getId(), client.firstName, client.lastName, client.address));
app.MapDelete("/clientes", (int id) => data.DeleteClient(id));


app.Run();


