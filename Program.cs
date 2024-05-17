using Microsoft.EntityFrameworkCore;
using portifolioInvestimento.Configuration;
using portifolioInvestimento.Repositories;
using portifolioInvestimento.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conexao = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PortifolioDbContext>(options =>
    options.UseSqlServer(conexao));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IInvestimentoRepository, InvestimentoRepository>();
builder.Services.AddScoped<IInvestimentoService, InvestimentoService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();


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
