using Microsoft.Extensions.DependencyInjection;
using TildeDeclensions.Business.DeclensionRules;
namespace TildeDeclensions.Business
{
    public static class RuleRegistrationExtensions
    {
        public static IServiceCollection AddRules(this IServiceCollection services)
        {
            services.AddSingleton<AdjectiveComparativeDeclensionRule001>();

            services.AddSingleton<FirstDeclensionRule001>();
            services.AddSingleton<FirstDeclensionRule002>();

            services.AddSingleton<FourthDeclensionRule001>();

            return services;
        }
    }
}
