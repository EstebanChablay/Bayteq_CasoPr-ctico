using SerpientesYEscalerasAPI.Modelo;
using SerpientesYEscalerasAPI.Servicio;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios necesarios para los controladores
builder.Services.AddControllers();

// Registrar el servicio de Tablero
builder.Services.AddSingleton<Tablero>(); // Puede ser Singleton porque su estado no cambia

// Registrar el servicio de Juego
builder.Services.AddScoped<IJuegoService, JuegoService>();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Permitir el frontend de React
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();
app.UseCors("PermitirFrontend");

// Configurar el middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

// Mapear los controladores
app.MapControllers();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
        return;
    }
    await next();
});

app.Run();
