using Microsoft.EntityFrameworkCore;
using Trabalho_BD.Components;
using Trabalho_BD.Data.Models;
using Trabalho_BD.Data.Services;
using Trabalho_BD.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configuração do EntityFramework
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(connectionString));

//Registrando os Serviços
builder.Services.AddScoped<ColetaService>();
builder.Services.AddScoped<DoacaoService>();
builder.Services.AddScoped<DoadorService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<EstoqueService>();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<HemocentroService>();
builder.Services.AddScoped<ReceptorService>();
builder.Services.AddScoped<TipoSanguineoService>();
builder.Services.AddScoped<TransfusaoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
