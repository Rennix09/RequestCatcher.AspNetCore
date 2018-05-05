using System;
using System.Collections.Generic;
using System.Text;

namespace RequestCatcher.AspNetCore
{
    public interface IRequestCatcherPersistencer
    {
		void Persistence(IRequestModel model);
	}
}
