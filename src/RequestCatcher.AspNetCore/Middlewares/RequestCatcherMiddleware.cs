using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RequestCatcher.AspNetCore.Validators;

namespace RequestCatcher.AspNetCore.Middlewares
{
    public class RequestCatcherMiddleware
    {
		private readonly RequestDelegate _next;
		private readonly IRequestCatcherPersistencer _persistencer;
		private readonly IRequestCatcherValidator _validator;
		private readonly RequestCatcherOptions _options;
		private readonly ILogger<RequestCatcherMiddleware> _logger;

		public RequestCatcherMiddleware(RequestDelegate next,
			 IRequestCatcherPersistencer persistencer,
			 IRequestCatcherValidator validator,
			 IOptions<RequestCatcherOptions> options,
			 ILogger<RequestCatcherMiddleware> logger)
		{
			_next = next;
			_persistencer = persistencer;
			_validator = validator;
			_logger = logger;
			_options = options.Value;
		}

		public Task Invoke(HttpContext context)
		{
			string path = context.Request.Path.ToString().ToLower();
			string method = context.Request.Method.ToLower();
			try
			{
				if (_validator.Validate(path, method))
				{
					var model = _options.ModelBuilder(context);
					_persistencer.Persistence(model);
				}
				return _next(context);
			}
			catch (Exception ex)
			{
				context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
				context.Response.WriteAsync(ex.Message);
				return Task.CompletedTask; ;
			}
		}
	}
}
