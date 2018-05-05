using System;
using System.Collections.Generic;
using System.Text;

namespace RequestCatcher.AspNetCore
{
    public class DefaultRequestModel : IRequestModel
	{
		 public string Method { get; set; }
		 public string Path { get; set; }
		 public object Parameters { get; set; }
    }
}
