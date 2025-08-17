using ControleAcces.API.DependencyInjection;
using ControleAcces.Application.Services;
using ControleAcces.Application.UseCases;
using ControleAcces.BlazorUI.Components;
using ControleAcces.Domain.Interfaces;
using ControleAcces.Infrastructure.Data;
using ControleAcces.Infrastructure.Repositories;
using ControleAcces.Infrastructure.ServicesExternes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControleAccesDependencies(builder.Configuration);



//builder.Services.AddHttpClient<IHardwareService, HardwareService>(client =>
//{
//    client.BaseAddress = new Uri("http://localhost:5001/"); // Remplace avec l'URL de ton module C++
//});

//builder.Services.AddHttpClient<IPaiementService, PaiementService>(client =>
//{
//    client.BaseAddress = new Uri("https://tonapi-paiement.com/"); // <-- Ton URL API Paiement

//});

//builder.Services.AddHttpClient<IAccesService, AccesService>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:7001/"); // Adresse de ton API locale
//});

//builder.Services.AddScoped<IEtudiantRepository, EtudiantRepository>();
//builder.Services.AddScoped<ISalleRepository, SalleRepository>();
//builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
//builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
//builder.Services.AddScoped<IHoraireExamenRepository, HoraireExamenRepository>();
//builder.Services.AddScoped<IAccesExamenRepository, AccesExamenRepository>();
//builder.Services.AddScoped<IJournalPresenceRepository, JournalPresenceRepository>();
//builder.Services.AddScoped<IIdentifiantRepository, IdentifiantRepository>();
//builder.Services.AddScoped<ISessionRepository, SessionRepository>();


//builder.Services.AddScoped<EtudiantService>();
//builder.Services.AddScoped<SalleService>();
//builder.Services.AddScoped<ModuleService>();
//builder.Services.AddScoped<PromotionService>();
//builder.Services.AddScoped<HoraireExamenService>();
//builder.Services.AddScoped<AccesExamenService>();
//builder.Services.AddScoped<JournalPresenceService>();
//builder.Services.AddScoped<IdentifiantService>();
//builder.Services.AddScoped<SessionService>();


builder.Services.AddScoped<EnrolerEtudiantUseCase>();
builder.Services.AddScoped<ControlerAccesExamenUseCase>();
builder.Services.AddScoped<PointerPresenceUseCase>();
builder.Services.AddScoped<GenererRapportPresenceUseCase>();
builder.Services.AddScoped<CreerSessionUseCase>();
builder.Services.AddScoped<AffecterModulesAuxSallesUseCase>();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



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
