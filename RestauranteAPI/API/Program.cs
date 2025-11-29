using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using DA;
using DA.Repositorios;
using Flujo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IProductoFlujo, ProductoFlujo>();
builder.Services.AddScoped<IProductoDA, ProductoDA>();
builder.Services.AddScoped<IRepositorioDapper, RepositorioDapper>();

builder.Services.AddScoped<ISubCategoriaDA, SubCategoriaDA>();
builder.Services.AddScoped<ISubCategoriaFlujo, SubCategoriaFlujo>();

builder.Services.AddScoped<ICategoriaDA, CategoriaDA>();
builder.Services.AddScoped<ICategoriaFlujo, CategoriaFlujo>();


builder.Services.AddScoped<ICarritoFlujo, CarritoFlujo>();
builder.Services.AddScoped<ICarritoDA, CarritoDA>();

builder.Services.AddScoped<ICuentaFlujo, CuentaFlujo>();
builder.Services.AddScoped<ICuentaDA, CuentaDA>();

builder.Services.AddScoped<IFacturaDA, FacturaDA>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
