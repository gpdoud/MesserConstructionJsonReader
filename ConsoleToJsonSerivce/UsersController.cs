using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleToJsonSerivce {

	public class UsersController {

		private static string URL = "http://prs.doudsystems.com/Users/";
		private HttpWebRequest request = null;
		private JavaScriptSerializer serializer = null;

		public IEnumerable<User> List() {
			var request = GetRequest("List");
			try {
				var response = request.GetResponse();
				var responseStream = response.GetResponseStream();
				var reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
				var json = reader.ReadToEnd();
				var users = serializer.Deserialize<User[]>(json);
				responseStream.Dispose();
				return users;
			} catch (WebException ex) {
				WebExceptionHandler(ex);
				throw ex;
			}
		}

		public User Get(int ID) {
			var request = GetRequest($"Get/{ID}");
			try {
				var response = request.GetResponse();
				var responseStream = response.GetResponseStream();
				var reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
				var json = reader.ReadToEnd();
				var user = serializer.Deserialize<User>(json);
				responseStream.Dispose();
				return user;
			} catch (WebException ex) {
				WebExceptionHandler(ex);
				throw ex;
			}
		}

		private void WebExceptionHandler(WebException ex) {
			WebResponse errorResponse = ex.Response;
			using (Stream responseStream = errorResponse.GetResponseStream()) {
				StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
				string errorText = reader.ReadToEnd();
			}
		}

		private HttpWebRequest GetRequest(string method) { 
			request = (HttpWebRequest)WebRequest.Create(URL + method);
			return request;
		}

		public UsersController() {
			serializer = new JavaScriptSerializer();
		}
	}
}
