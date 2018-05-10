using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToJsonSerivce {

	public class Project {
		public string project_id { get; set; }
		public string name { get; set; }
		public string created { get; set; }
		public string modified { get; set; }
		public string abbreviation { get; set; }
		public string contact { get; set; }
		public string email { get; set; }
		public string active { get; set; }
		public string phone { get; set; }
		public string address { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string country { get; set; }
		public string zip { get; set; }
		public string custom_field_1 { get; set; }
		public string custom_field_2 { get; set; }
		public string custom_field_3 { get; set; }
		public string custom_field_4 { get; set; }
		public string custom_field_5 { get; set; }
		public string value { get; set; }
		public string started { get; set; }
		public string completed { get; set; }
		public string job_number { get; set; }
	}
}
