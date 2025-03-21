using Microsoft.Extensions.DependencyInjection;
using TildeDeclensions.Business.DeclensionRules;
namespace TildeDeclensions.Business
{
    public static class RuleRegistrationExtensions
    {
        public static IServiceCollection AddRules(this IServiceCollection services)
        {
            services.AddTransient<AdjectiveComparativeDeclensionRule001>();

            services.AddTransient<FirstDeclensionRule001>();
            services.AddTransient<FirstDeclensionRule002>();

            services.AddTransient<FourthDeclensionRule001>();

            return services;
        }
    }
}
