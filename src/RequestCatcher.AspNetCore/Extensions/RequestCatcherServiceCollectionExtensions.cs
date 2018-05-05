using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using RequestCatcher.AspNetCore.Validators;

namespace RequestCatcher.AspNetCore
{
    public static class RequestCatcherServiceCollectionExtensions
    {
		public static IServiceCollection AddRequestCatcher(this IServiceCollection services,Action<RequestCatcherOptions> options)
		{
			services.AddOptions();
			services.Configure(options);

			services.AddSingleton<IRequestCatcherPersistencer, DefaultRequestCatcherPersistencer>();
			services.AddSingleton<IRequestCatcherValidator, DefaultRequestCatcherValidator>();

			return services;
		}

		public static IServiceCollection AddRequestCatcherPersistencer<T>(this IServiceCollection services) where T: IRequestCatcherPersistencer
		{
			services.AddSingleton(typeof(IRequestCatcherPersistencer), typeof(T));
			return services;
		}

		public static IServiceCollection AddRequestCatcherValidator<T>(this IServiceCollection services) where T : IRequestCatcherValidator
		{
			services.AddSingleton(typeof(IRequestCatcherValidator), typeof(T));
			return services;
		}
	}
}
