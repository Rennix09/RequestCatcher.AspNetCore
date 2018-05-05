using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace RequestCatcher.AspNetCore
{
	public class DefaultRequestCatcherPersistencer : IRequestCatcherPersistencer
	{
		private readonly ILogger<DefaultRequestCatcherPersistencer> _logger;

		public DefaultRequestCatcherPersistencer(ILogger<DefaultRequestCatcherPersistencer> logger)
		{
			_logger = logger;
		}

		public void Persistence(IRequestModel model)
		{
			var str = Newtonsoft.Json.JsonConvert.SerializeObject(model);
			_logger.LogInformation($"[RequestCatcher]-{DateTime.Now.ToString()}:{str}");
		}
	}
}
