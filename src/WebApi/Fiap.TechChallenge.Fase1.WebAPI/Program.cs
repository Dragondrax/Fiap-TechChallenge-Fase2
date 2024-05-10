using Fiap.TechChallenge.Fase1.Data.Context;
using Fiap.TechChallenge.Fase1.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllButCredentials", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

InjecaoDependenciaConfig.ResolverDependencia(builder.Services);

builder.Services.AddDbContext<Fiap.TechChallenge.Fase1.Data.Context.ContextTechChallenge>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("conexao"), x => x.MigrationsAssembly("Fiap.TechChallenge.Fase1.Data")).UseLowerCaseNamingConvention();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllButCredentials");


app.UseAuthorization();

app.MapControllers();

app.Run();
