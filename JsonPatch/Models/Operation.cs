using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonPatch.Models
{
	public class Operation
	{

		public string Op { get; set; }
		public string Path { get; set; }
		public int Key { get; set; }
		public dynamic Value { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public List<Paramater> Values { get; set; } 
	}
}
