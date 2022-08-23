using Application.Interfaces;
using Application.Servicio;
using data.Constructores;
using Data.Constructores;
using Data.Consultas;
using Microsoft.EntityFrameworkCore;
using ProyectoSoftwareIndividual.Contexto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProyectoSoftwareLibreriaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IClienteCrear, ConstructorClientes>();
builder.Services.AddTransient<IConsultarCliente, ConsultarCliente>();
builder.Services.AddTransient<IAlquilerService, AlquilerService>();
builder.Services.AddTransient<IConsultarAlquiler, ConsultarTodosLosAlquileres>();
builder.Services.AddTransient<IAlquilerCrear, AlquilerCrear>();
builder.Services.AddTransient<IConsultarLibro, ConsultaDeLibros>();
builder.Services.AddTransient<IConsultarEstado, ConsultaDeEstado>();
builder.Services.AddTransient<ILibroService, LibroService>();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
