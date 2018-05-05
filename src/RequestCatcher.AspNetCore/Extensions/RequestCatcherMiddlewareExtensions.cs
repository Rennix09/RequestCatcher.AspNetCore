using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using RequestCatcher.AspNetCore.Middlewares;

namespace RequestCatcher.AspNetCore
{
    public static class RequestCatcherMiddlewareExtensions
    {
		public static IApplicationBuilder UseRequestCatcher(
		   this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<RequestCatcherMiddleware>();
		}
	}
}
