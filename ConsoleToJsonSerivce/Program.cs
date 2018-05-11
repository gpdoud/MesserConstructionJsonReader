using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleToJsonSerivce {

	class Program {

		void ListContacts() {
			var lctrl = new LatistaController();
			var contacts = lctrl.ListContacts();
			//Display($"offset:{contacts.offset}, limit:{contacts.limit}, total:{contacts.total}");
			//foreach (var c in contacts.contacts) {
			//	Display($"id:{c.user_id}, firstname:{c.first_name}, lastname:{c.last_name}, company name: {c.company_name}");
			//}
			SqlLoader sql = new SqlLoader();
			foreach( var contact in contacts.contacts) {
				var success = sql.LoadContact(contact);
			}
		}

		void ListProjects() {
			var lctrl = new LatistaController();
			var projects = lctrl.ListProjects();
			Display($"offset:{projects.offset}, limit:{projects.limit}, total:{projects.total}");
			foreach(var p in projects.projects) {
				Display($"id:{p.project_id}, name:{p.name}, job number:{p.job_number}");
			}
		}

		void List() {
			var UserCtrl = new UsersController();
			var users = UserCtrl.List();
			foreach (var user in users) {
				Display($"{user.FirstName} {user.LastName}");
			}
		}

		void Get(int ID) {
			var UserCtrl = new UsersController();
			var user = UserCtrl.Get(ID);
			Display($"{user.FirstName} {user.LastName}");
		}

		void Display(string message) {
			System.Diagnostics.Debug.WriteLine(message);
			Console.WriteLine(message);
		}

		void Run() {
			ListContacts();
			//ListProjects();
			//List();
			//Get(2);
		}

		static void Main(string[] args) {
			(new Program()).Run();
		}
	}
}
