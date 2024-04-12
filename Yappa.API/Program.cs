using MicroRabbit.YappaApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Yappa.Repositories;
using Yappa.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<YappaAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("YappaDBConnection"));
});

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<YappaAppDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





#region Plantillas de Configuraci�n CORS
/*
// Configuraci�n CORS: Permitir or�genes, m�todos y encabezados espec�ficos

//options.AddPolicy("CorsPolicy", builder =>
//    builder.WithOrigins("http://ejemplo.com", "http://otro.com")
//        .WithMethods("GET", "POST", "PUT", "DELETE")
//        .WithHeaders("Autorizaci�n", "Content-Type")
//);


// Configuraci�n CORS: Permitir cualquier origen, pero m�todos y encabezados espec�ficos

//options.AddPolicy("CorsPolicy", builder =>
//    builder.AllowAnyOrigin()
//        .WithMethods("GET", "POST")
//        .WithHeaders("Content-Type")
//);


// Configuraci�n CORS: Permitir credenciales y or�genes espec�ficos

//options.AddPolicy("CorsPolicy", builder =>
//    builder.WithOrigins("http://ejemplo.com")
//        .AllowCredentials()
//);


// Configuraci�n CORS: Permitir cualquier origen, m�todo y encabezado (no recomendado para producci�n)

//options.AddPolicy("CorsPolicy", builder =>
//    builder.AllowAnyOrigin()
//        .AllowAnyMethod()
//        .AllowAnyHeader()
//);


// Configuraci�n CORS: Permitir m�ltiples or�genes usando patrones

//options.AddPolicy("CorsPolicy", builder =>
//    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
//        .WithOrigins("http://*.ejemplo.com", "http://*.otro.com")
//        .AllowAnyMethod()
//        .AllowAnyHeader()
//);


// Configuraci�n CORS: Permitir or�genes espec�ficos, pero con un encabezado expuesto espec�fico

//options.AddPolicy("CorsPolicy", builder =>
//    builder.WithOrigins("http://ejemplo.com")
//        .WithExposedHeaders("Encabezado-Custom")
//);
*/

#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
