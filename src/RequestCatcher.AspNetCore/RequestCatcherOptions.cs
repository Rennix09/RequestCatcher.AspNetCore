using System;
using System.Collections.Generic;
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
			var model = new DefaultRequestModel
			{
				Method = context.Request.Method.ToUpper(),
				Path = context.Request.Path,
			};
			return model;
		}
	}
}
