using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;

namespace RequestCatcher.AspNetCore.Validators
{
	public class DefaultRequestCatcherValidator : IRequestCatcherValidator
	{
		private readonly RequestCatcherOptions _options;
		public DefaultRequestCatcherValidator(IOptions<RequestCatcherOptions> options)
		{
			_options = options.Value;
		}

		public bool Validate(string requestPath, string requestMethod)
		{
			var allow = false;

			if (requestPath.Length > 1)
			{
				requestPath = requestPath?.TrimEnd('/');
			}

			foreach (var item in _options.EnableRules)
			{
				var allows = item.AllowMethod.Select(x => x.ToLower());
				var methodAloows = allows.Contains("all") || allows.Contains(requestMethod);

				if (!methodAloows)
					continue;

				if (_options.EnableRules.Any(x => x.Expression.Equals("/*")))
				{
					allow = true;
					break;
				}
				else
				{
					// 静态匹配和强匹配
					if (item.Expression.Equals(requestPath, StringComparison.CurrentCultureIgnoreCase))
					{
						allow = true;
						break;
					}
					else
					{
						var exp = item.Expression.Replace("/*", "/.*").Replace("/?", "/.?");
						if (Regex.IsMatch(requestPath, exp))
						{
							allow = true;
							break;
						}
					}
				}
			}

			return allow;
		}
	}
}
