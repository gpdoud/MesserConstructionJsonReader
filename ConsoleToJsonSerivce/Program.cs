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

		void ListProjects() {
			var lctrl = new LatistaController();
			var projects = lctrl.ListProjects();
			System.Diagnostics.Debug.WriteLine($"offset:{projects.offset}, limit:{projects.limit}, total:{projects.total}");
			foreach(var p in projects.projects) {
				System.Diagnostics.Debug.WriteLine($"id:{p.project_id}, name:{p.name}");
			}
		}

		void List() {
			var UserCtrl = new UsersController();
			var users = UserCtrl.List();
			foreach (var user in users) {
				Console.WriteLine($"{user.FirstName} {user.LastName}");
			}
		}

		void Get(int ID) {
			var UserCtrl = new UsersController();
			var user = UserCtrl.Get(ID);
			Console.WriteLine($"{user.FirstName} {user.LastName}");
		}

		void Run() {
			ListProjects();
			//List();
			//Get(2);
		}

		static void Main(string[] args) {
			(new Program()).Run();
		}
	}
}
