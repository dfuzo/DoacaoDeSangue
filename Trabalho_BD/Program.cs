using Microsoft.EntityFrameworkCore;
using Trabalho_BD.Components;
using Trabalho_BD.Data.Models;
using Trabalho_BD.Data.Services;
using Trabalho_BD.Data;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(connectionString));

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
builder.Services.AddScoped<PdfService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
