using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleToJsonSerivce {

	public class LatistaController {

		private static string URL = "https://app.latista.com/api/messer/";
		private HttpWebRequest request = null;
		private JavaScriptSerializer serializer = new JavaScriptSerializer();
		private static string username = "messerots@gmail.com";
		private static string password = "Sl@pshot212";
		private string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

		public Contacts ListContacts() {
			var request = GetRequest("contacts");
			request.Headers.Add("Authorization", "Basic " + encoded);
			try {
				var response = request.GetResponse();
				var responseStream = response.GetResponseStream();
				var reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
				var json = reader.ReadToEnd();
				serializer.MaxJsonLength = json.Length + 100;
				var contacts = serializer.Deserialize<Contacts>(json);
				responseStream.Dispose();
				return contacts;
			} catch (WebException ex) {
				WebExceptionHandler(ex);
				throw ex;
			}
		}

		public Projects ListProjects() {
			var request = GetRequest("projects");
			request.Headers.Add("Authorization", "Basic " + encoded);
			try {
				var response = request.GetResponse();
				var responseStream = response.GetResponseStream();
				var reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
				var json = reader.ReadToEnd();
				var projects = serializer.Deserialize<Projects>(json);
				responseStream.Dispose();
				return projects;
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
	}
}
