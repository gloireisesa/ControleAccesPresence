using ControleAcces.Application.Services;
using ControleAcces.Application.UseCases;
using ControleAcces.Domain.Interfaces;
using ControleAcces.Infrastructure.Repositories;
using ControleAcces.Infrastructure.ServicesExternes;

namespace ControleAcces.API.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddControleAccesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
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

            // External Services
            services.AddHttpClient<IPaiementService, PaiementService>(client =>
            {
                client.BaseAddress = new Uri("https://tonapi-paiement.com/");
            });

            // UseCases & Services Application Layer
            services.AddScoped<EnrolerEtudiantUseCase>();
            services.AddScoped<ControlerAccesExamenUseCase>();
            services.AddScoped<PointerPresenceUseCase>();
            services.AddScoped<GenererRapportPresenceUseCase>();
            services.AddScoped<SalleService>();
            services.AddScoped<SessionService>();
            services.AddScoped<ModuleService>();
            services.AddScoped<IdentifiantService>();
            services.AddScoped<PaiementVerifier>();

            return services;
        }
    }
}
