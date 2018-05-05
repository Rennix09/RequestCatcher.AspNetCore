using System;
using System.Collections.Generic;
using System.Text;

namespace RequestCatcher.AspNetCore.Models
{
    public class RuleItem
    {
		public string Expression { get; set; }
		public List<string> AllowMethod { get; set; }

		public static List<string> All = new List<string> { "All" };
    }
}
