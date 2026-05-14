using CrudApiDemo.Models;
using Microsoft.EntityFrameworkCore;

//Para ejecutar esta API tenemos que primero hacer una migracción y luego actualizar la base de datos, para esto usamos los siguientes comandos en la terminal en la Consola del Administrador de Paquetes NuGet:
//Add-Migration Initial
//Update-Database
//Para visualizar la documentación de la API con swagger tenemos que ir al siguiente enlace: https://localhost:puertoQueDesigneElSistema/swagger/index.html

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

// Manejo de errores global
app.Map("/error", (HttpContext context) =>
{
    var exception = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;
    return Results.Problem(
        title: "Ocurrió un error",
        detail: exception?.Message,
        statusCode: 500
    );
});

app.MapGet("/", () => "API REST EN .NET 10 WORKING NOW");

app.MapGet("api/productos", async (AppDbContext context) =>
{
    return await context.Productos.ToListAsync();
});

app.MapGet("api/productos/{id}", async (int id, AppDbContext context) =>
{
    var producto = await context.Productos.FindAsync(id);
    return producto is not null ? Results.Ok(producto) : Results.NotFound();
});

app.MapPost("api/productos", async (Producto producto, AppDbContext context) =>
{
    context.Productos.Add(producto);
    await context.SaveChangesAsync();
    return Results.Created($"/api/productos/{producto.Id}", producto);
});

app.MapPut("api/productos/{id}", async (int id, Producto producto, AppDbContext context) =>
{
    var findProducto = await context.Productos.FindAsync(id);
    if (findProducto is null)
    {
        return Results.NotFound();
    }

    findProducto.Nombre = producto.Nombre;
    findProducto.Precio = producto.Precio;
    findProducto.Stock = producto.Stock;

    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("api/productos/{id}", async (int id, AppDbContext context) =>
{
    var producto = await context.Productos.FindAsync(id);
    if (producto is null)
    {
        return Results.NotFound();
    }
    context.Productos.Remove(producto);
    await context.SaveChangesAsync();
    return Results.NoContent();
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
