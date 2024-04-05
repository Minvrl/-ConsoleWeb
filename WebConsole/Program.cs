using Microsoft.EntityFrameworkCore;
using WebConsole;
using WebConsole.Entities;


AppDbContext appDbContext = new AppDbContext();

var appBuilder = WebApplication.CreateBuilder();



appBuilder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


var app = appBuilder.Build();

app.UseCors("AllowAll");

app.MapGet("/", () =>
{
    return "Hello, World!";
});

app.MapGet("/products", async () =>
{
    var products = await appDbContext.Products.ToListAsync();
    return products;
});


app.MapGet("/products/{id}", (int id) =>
{
    var data = appDbContext.Products.Find(id);

    if (data == null) return Results.NotFound("Not found!");

    return Results.Ok(data);
});

app.MapPost("/products", (Product product) =>
{
    appDbContext.Add(product);
    appDbContext.SaveChanges();

    return Results.Ok();
});


app.Run();