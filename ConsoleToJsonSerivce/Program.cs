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
			//List();
			Get(2);
		}

		static void Main(string[] args) {
			(new Program()).Run();
		}
	}
}
