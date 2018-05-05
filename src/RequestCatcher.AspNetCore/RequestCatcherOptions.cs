using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using RequestCatcher.AspNetCore.Models;

namespace RequestCatcher.AspNetCore
{
	public class RequestCatcherOptions
	{
		public RequestCatcherOptions()
		{
			this.ModelBuilder = DefaultModelBuilder;
			this.EnableRules = new List<RuleItem>();
		}

		public List<RuleItem> EnableRules { get; set; }

		public Func<HttpContext, IRequestModel> ModelBuilder { get; set; }

		private IRequestModel DefaultModelBuilder(HttpContext context)
		{
			var headers = new Dictionary<string, string>();

			foreach (var item in context.Request.Headers)
			{
				headers.Add(item.Key, item.Value);
			}

			var model = new DefaultRequestModel
			{
				Method = context.Request.Method.ToUpper(),
				Path = context.Request.Path,
				UserAgent = headers.FirstOrDefault(x => x.Key.ToLower() == "user-agent"),
				Scheme = context.Request.Scheme.ToUpper(),
				IsHttps = context.Request.IsHttps,
				AcceptLanguage = headers.FirstOrDefault(x => x.Key.ToLower() == "accept-language"),
				Cookie = headers.FirstOrDefault(x => x.Key.ToLower() == "cookie"),
				Referer = headers.FirstOrDefault(x => x.Key.ToLower() == "referer"),
				Host = headers.FirstOrDefault(x => x.Key.ToLower() == "host"),
				Date = DateTime.Now,
				IsAuth = context.User != null,
				UserName = context.User.Identity.Name,
				Form = context.Request.HasFormContentType ? context.Request.Form.ToList():new List<KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>>(),
				QueryString = context.Request.QueryString.ToString(),
				ContentType = context.Request.ContentType,
				ContentLength = context.Request.ContentLength
			};
			return model;
		}
	}
}
