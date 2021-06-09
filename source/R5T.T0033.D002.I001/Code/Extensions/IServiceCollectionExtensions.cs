using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.T0033.D002.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="StringSubstitutionInterpreter"/> implementation of <see cref="IStringSubstitutionInterpreter"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStringSubstitutionInterpreter(this IServiceCollection services)
        {
            services.AddSingleton<IStringSubstitutionInterpreter, StringSubstitutionInterpreter>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StringSubstitutionInterpreter"/> implementation of <see cref="IStringSubstitutionInterpreter"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IStringSubstitutionInterpreter> AddStringSubstitutionInterpreterAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IStringSubstitutionInterpreter>(() => services.AddStringSubstitutionInterpreter());
            return serviceAction;
        }
    }
}
