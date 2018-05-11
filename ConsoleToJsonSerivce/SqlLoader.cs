using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToJsonSerivce {

	public class SqlLoader {

		SqlCommand cmd = null;

		public bool LoadContact(Contact contact) {
			if (cmd == null)
				cmd = Init();

			cmd.Parameters["@user_id"].Value = Transform(contact.user_id);
			cmd.Parameters["@contact_id"].Value = Transform(contact.contact_id);
			cmd.Parameters["@user_name"].Value = Transform(contact.user_name);
			cmd.Parameters["@first_name"].Value = Transform(contact.first_name);
			cmd.Parameters["@last_name"].Value = Transform(contact.last_name);
			cmd.Parameters["@title"].Value = Transform(contact.title);
			cmd.Parameters["@email_address"].Value = Transform(contact.email_address);
			cmd.Parameters["@is_manager"].Value = Transform(contact.is_manager);
			cmd.Parameters["@manager_user_id"].Value = Transform(contact.manager_user_id);
			cmd.Parameters["@backup_user_id"].Value = Transform(contact.backup_user_id);
			cmd.Parameters["@restriction_type"].Value = Transform(contact.restriction_type);
			cmd.Parameters["@is_active"].Value = Transform(contact.is_active);
			cmd.Parameters["@address1"].Value = Transform(contact.address1);
			cmd.Parameters["@address2"].Value = Transform(contact.address2);
			cmd.Parameters["@city"].Value = Transform(contact.city);
			cmd.Parameters["@state"].Value = Transform(contact.state);
			cmd.Parameters["@zip_code"].Value = Transform(contact.zip_code);
			cmd.Parameters["@country"].Value = Transform(contact.country);
			cmd.Parameters["@phone_number"].Value = Transform(contact.phone_number);
			cmd.Parameters["@mobile"].Value = Transform(contact.mobile);
			cmd.Parameters["@fax_number"].Value = Transform(contact.fax_number);
			cmd.Parameters["@company_id"].Value = Transform(contact.company_id);
			cmd.Parameters["@company_name"].Value = Transform(contact.company_name);
			cmd.Parameters["@role_id"].Value = Transform(contact.role_id);
			cmd.Parameters["@role_name"].Value = Transform(contact.role_name);
			cmd.Parameters["@created"].Value = Transform(contact.created);
			cmd.Parameters["@last_updated"].Value = Transform(contact.last_updated);
			int recsAffected = cmd.ExecuteNonQuery();
			if(recsAffected != 1) {
				throw new Exception("Insert may have failed with recs affected = " + recsAffected);
			}
			return true;
		}

		private string Transform(string input, string ifNull = "") {
			return input ?? ifNull;
		}

		public SqlCommand Init() {
			string connStr = @"server=localhost\SQLEXPRESS;database=messer;Trusted_connection=true";
			SqlConnection conn = new SqlConnection(connStr);
			conn.Open();
			if(conn.State != System.Data.ConnectionState.Open) {
				throw new Exception("Connection did not open.");
			}
			var sql = " insert into contacts("
				+ "user_id ,	contact_id ,	user_name ,	first_name ,	last_name ,	title ,	email_address ,	is_manager ,	manager_user_id ,	backup_user_id ,	restriction_type ,	is_active ,	address1 ,	address2 ,	city ,	state ,	zip_code ,	country ,	phone_number ,	mobile ,	fax_number ,	company_id ,	company_name ,	role_id ,	role_name ,	created ,	last_updated)"
				+ " values "
				+ "(@user_id,	@contact_id,	@user_name,	@first_name,	@last_name,	@title,	@email_address,	@is_manager,	@manager_user_id,	@backup_user_id,	@restriction_type,	@is_active,	@address1,	@address2,	@city,	@state,	@zip_code,	@country,	@phone_number,	@mobile,	@fax_number,	@company_id,	@company_name,	@role_id,	@role_name,	@created,	@last_updated)";

			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Clear();
			cmd.Parameters.Add(new SqlParameter("@address1", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@address2", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@backup_user_id", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@city", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@company_id", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@company_name", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@contact_id", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@country", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@created", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@email_address", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@fax_number", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@first_name", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@is_active", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@is_manager", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@last_name", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@last_updated", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@manager_user_id", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@mobile", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@phone_number", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@restriction_type", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@role_id", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@role_name", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@state", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@title", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@user_id", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@user_name", System.Data.SqlDbType.VarChar, int.MaxValue));
			cmd.Parameters.Add(new SqlParameter("@zip_code", System.Data.SqlDbType.VarChar, int.MaxValue));
			return cmd;

		}

	}
}
