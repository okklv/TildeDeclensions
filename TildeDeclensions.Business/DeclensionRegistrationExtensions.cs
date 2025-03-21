using Microsoft.Extensions.DependencyInjection;
using TildeDeclensions.Business.DeclensionRules;
using TildeDeclensions.Business.DeclensionServices;

namespace TildeDeclensions.Business
{
    public static class DeclensionRegistrationExtensions
    {

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddTransient(sp =>
                new FirstDeclensionHandler(
                    [
                        sp.GetRequiredService<FirstDeclensionRule001>(),
                        sp.GetRequiredService<FirstDeclensionRule002>()
                    ])
                );

            services.AddTransient(sp =>
                new FourthDeclensionHandler(
                    [
                        sp.GetRequiredService<FourthDeclensionRule001>()
                    ])
                );

            services.AddTransient(sp =>
                new AdjectiveComparativeDeclensionHandler(
                    [
                        sp.GetRequiredService<AdjectiveComparativeDeclensionRule001>()
                    ],
                    sp.GetRequiredService<FirstDeclensionHandler>(), sp.GetRequiredService<FourthDeclensionHandler>())
                );


            services.AddTransient<Func<IDeclensionHandler>>(sp => () =>
            {
                var firstDeclensionHandler = sp.GetRequiredService<FirstDeclensionHandler>();
                var fourthDeclensionHandler = sp.GetRequiredService<FourthDeclensionHandler>();
                var adjectiveComparativeDeclensionHandler = sp.GetRequiredService<AdjectiveComparativeDeclensionHandler>();

                firstDeclensionHandler.SetNext(fourthDeclensionHandler);
                fourthDeclensionHandler.SetNext(adjectiveComparativeDeclensionHandler);

                return firstDeclensionHandler;
            });

            return services;
        }
    }
}
