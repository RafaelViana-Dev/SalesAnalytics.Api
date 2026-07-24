using SalesAnalytics.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Registro do serviço de analytics para injeção de dependência
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

// Configuração do CORS (Permite chamadas de qualquer origem para testes locais)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowAll"); // Habilita a política de CORS

app.UseAuthorization();

app.MapControllers();

app.Run();
