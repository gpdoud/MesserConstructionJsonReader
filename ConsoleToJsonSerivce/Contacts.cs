using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToJsonSerivce {

	public class Contacts {

		public string offset { get; set; }
		public string limit { get; set; }
		public string total { get; set; }
		public IEnumerable<Contact> contacts { get; set; }

	}
}
