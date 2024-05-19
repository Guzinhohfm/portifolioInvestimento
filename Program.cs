using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using portifolioInvestimento.Configuration;
using portifolioInvestimento.Interfaces;
using portifolioInvestimento.Repositories;
using portifolioInvestimento.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiPortifolioInvestimento", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

}


); 

var conexao = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PortifolioDbContext>(options =>
    
    options.UseSqlServer(conexao));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IInvestimentoRepository, InvestimentoRepository>();
builder.Services.AddScoped<IInvestimentoService, InvestimentoService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();


builder.Services.AddHostedService<EmailSenderService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DatabaseManagment.MigrationInitialization(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

