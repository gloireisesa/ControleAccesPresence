using ControleAcces.Application.Services;
using ControleAcces.Application.UseCases;
using ControleAcces.Domain.Interfaces;
using ControleAcces.Infrastructure.Data;
using ControleAcces.Infrastructure.Repositories;
using ControleAcces.Infrastructure.ServicesExternes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleAcces.API.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddControleAccesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            // Repositories
            services.AddScoped<IEtudiantRepository, EtudiantRepository>();
            services.AddScoped<ISalleRepository, SalleRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IHoraireExamenRepository, HoraireExamenRepository>();
            services.AddScoped<IAccesExamenRepository, AccesExamenRepository>();
            services.AddScoped<IJournalPresenceRepository, JournalPresenceRepository>();
            services.AddScoped<IIdentifiantRepository, IdentifiantRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();



            // External Services


            services.AddHttpClient<IHardwareService, HardwareService>(client =>
            {
                client.BaseAddress = new Uri("http://10.107.22.160:80/"); // Remplace avec l'URL de ton module C++
            });

            services.AddHttpClient<IPaiementService, PaiementService>(client =>
            {
                client.BaseAddress = new Uri("https://tonapi-paiement.com/");
            });
            //services.AddHttpClient<IPaiementService, PaiementService>(client =>
            {
                // client.BaseAddress = new Uri("https://tonapi-paiement.com/");
                //});

                // UseCases & Services Application Layer
                services.AddScoped<EnrolerEtudiantUseCase>();
                services.AddScoped<ControlerAccesExamenUseCase>();
                services.AddScoped<PointerPresenceUseCase>();
                services.AddScoped<GenererRapportPresenceUseCase>();
                services.AddScoped<AffecterModulesAuxSallesUseCase>();
                services.AddScoped<CreerSessionUseCase>();
                services.AddSingleton<RapportPdfService>();
                services.AddHttpContextAccessor();




                services.AddScoped<AccesService>();
                services.AddScoped<SalleService>();
                services.AddScoped<SessionService>();
                services.AddScoped<ModuleService>();
                services.AddScoped<IdentifiantService>();
                services.AddScoped<PaiementVerifier>();
                services.AddScoped<HoraireExamenService>();
                services.AddScoped<EtudiantService>();
                services.AddScoped<PromotionService>();
                services.AddScoped<JournalPresenceService>();
                //services.AddScoped<HardwareService>();
                services.AddScoped<AuthService>();


                return services;
            }
        }
    }
}