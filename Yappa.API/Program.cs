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





#region Plantillas de Configuración CORS
/*
// Configuración CORS: Permitir orígenes, métodos y encabezados específicos

//options.AddPolicy("CorsPolicy", builder =>
//    builder.WithOrigins("http://ejemplo.com", "http://otro.com")
//        .WithMethods("GET", "POST", "PUT", "DELETE")
//        .WithHeaders("Autorización", "Content-Type")
//);


// Configuración CORS: Permitir cualquier origen, pero métodos y encabezados específicos

//options.AddPolicy("CorsPolicy", builder =>
//    builder.AllowAnyOrigin()
//        .WithMethods("GET", "POST")
//        .WithHeaders("Content-Type")
//);


// Configuración CORS: Permitir credenciales y orígenes específicos

//options.AddPolicy("CorsPolicy", builder =>
//    builder.WithOrigins("http://ejemplo.com")
//        .AllowCredentials()
//);


// Configuración CORS: Permitir cualquier origen, método y encabezado (no recomendado para producción)

//options.AddPolicy("CorsPolicy", builder =>
//    builder.AllowAnyOrigin()
//        .AllowAnyMethod()
//        .AllowAnyHeader()
//);


// Configuración CORS: Permitir múltiples orígenes usando patrones

//options.AddPolicy("CorsPolicy", builder =>
//    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
//        .WithOrigins("http://*.ejemplo.com", "http://*.otro.com")
//        .AllowAnyMethod()
//        .AllowAnyHeader()
//);


// Configuración CORS: Permitir orígenes específicos, pero con un encabezado expuesto específico

//options.AddPolicy("CorsPolicy", builder =>
//    builder.WithOrigins("http://ejemplo.com")
//        .WithExposedHeaders("Encabezado-Custom")
//);
*/

#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
