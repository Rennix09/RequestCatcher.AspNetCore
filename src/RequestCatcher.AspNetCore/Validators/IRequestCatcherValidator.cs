using System;
using System.Collections.Generic;
using System.Text;

namespace RequestCatcher.AspNetCore.Validators
{
    public interface IRequestCatcherValidator
    {
		bool Validate(string requestPath,string requestMethod);
    }
}
