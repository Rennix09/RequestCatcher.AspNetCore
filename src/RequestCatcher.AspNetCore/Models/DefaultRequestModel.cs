using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace RequestCatcher.AspNetCore
{
    public class DefaultRequestModel : IRequestModel
	{
		 public string Method { get; set; }
		 public string Path { get; set; }
		public KeyValuePair<string, string> UserAgent { get;  set; }
		public string Scheme { get; internal set; }
		public bool IsHttps { get; internal set; }
		public KeyValuePair<string, string> AcceptLanguage { get; internal set; }
		public KeyValuePair<string, string> Host { get; internal set; }
		public string UserName { get; internal set; }
		public DateTime Date { get; internal set; }
		public KeyValuePair<string, string> Referer { get; internal set; }
		public KeyValuePair<string, string> Cookie { get; internal set; }
		public bool IsAuth { get; internal set; }
		public List<KeyValuePair<string, StringValues>> Form { get; internal set; }
		public object QueryString { get; internal set; }
		public string ContentType { get; internal set; }
		public long? ContentLength { get; internal set; }
	}
}
