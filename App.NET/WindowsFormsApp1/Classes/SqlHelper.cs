using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
	public static class SqlHelper
	{
		public static string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

		public static IList<string> GetTables(string queryString)
		{
			var tables = new List<string>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader =  command.ExecuteReader();
				try
				{
					while (reader.Read())
					{
						//if(!reader["TABLE_NAME"].ToString().Contains("Report"))
						tables.Add(reader["TABLE_NAME"].ToString());
					}
				}
				finally
				{
					reader.Close();
				}
			}

			return tables;
		}

		public static IList<string> GetReports(string queryString)
		{
			var tables = new List<string>();
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();
				var reader = command.ExecuteReader();
				try
				{
					while (reader.Read())
					{
						tables.Add(reader["ReportName"].ToString());
					}
				}
				finally
				{
					reader.Close();
				}
			}

			return tables;
		}

		public static IList<string> GetViews(string queryString)
		{
			var tables = new List<string>();
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();
				var reader = command.ExecuteReader();
				try
				{
					while (reader.Read())
					{
						tables.Add(reader["Name"].ToString());
					}
				}
				finally
				{
					reader.Close();
				}
			}

			return tables;
		}

		public static string GetReportSP(string reportName)
		{
			string reportSP = default;
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand(SqlScripts.SelectReportSP + "'" + reportName + "'", connection);
				connection.Open();
				var reader = command.ExecuteReader();
				try
				{
					while (reader.Read())
					{
						reportSP = reader["StoredProcedure"].ToString();
					}
				}
				finally
				{
					reader.Close();
				}
			}

			return reportSP;
		}

		public static DataSet GetTableDataSet(string name)
		{
			DataSet ds = new DataSet();

			using (SqlConnection connection = new SqlConnection(connString))
			{
				connection.Open();
				SqlDataAdapter da = new SqlDataAdapter();
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandText = SqlScripts.SelectScript + GetTableName(name);
				da.SelectCommand = cmd;
				da.Fill(ds);
			}

			return ds;
		}

		public static void SaveAndCommitToDb(DataSet dataset, string currentTable)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				DataSet newDataSet = new DataSet();
				SqlDataAdapter newDataAdapter = new SqlDataAdapter();
				newDataAdapter.SelectCommand = new SqlCommand(SqlScripts.SelectScript + GetTableName(currentTable), conn);
				SqlCommandBuilder cb = new SqlCommandBuilder(newDataAdapter);
				newDataAdapter.Fill(newDataSet);

				newDataAdapter.UpdateCommand = cb.GetUpdateCommand();
				newDataAdapter.Update(dataset, dataset.Tables[0].TableName);
				
				conn.Close();
			}
		}

		public static DataSet GetSPParams(string spName)
		{
			DataSet ds = new DataSet();

			using (SqlConnection connection = new SqlConnection(connString))
			{
				connection.Open();
				SqlDataAdapter da = new SqlDataAdapter();
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandText = SqlScripts.SelectSPParams + spName.Split('.')[1] + "'";
				da.SelectCommand = cmd;
				da.Fill(ds);
			}

			return ds;
		}

		public static DataSet ExecSpWithParams(string spName, params SqlParameter[] sqlParameters)
		{
			DataSet ds = new DataSet();

			using (SqlConnection connection = new SqlConnection(connString))
			{
				connection.Open();
				SqlDataAdapter da = new SqlDataAdapter();
				SqlCommand cmd = new SqlCommand(spName, connection);
				cmd.CommandType = CommandType.StoredProcedure;

				foreach (var param in sqlParameters)
					cmd.Parameters.Add(param);

				da.SelectCommand = cmd;
				da.Fill(ds);
			}

			return ds;
		}

		private static string GetTableName(string nameWithSchema)
		{
			var splittedString = nameWithSchema.Split('.');
			StringBuilder builder = new StringBuilder();
			builder.Append("[");
			builder.Append(splittedString[0]);
			builder.Append("].");
			builder.Append("[");
			builder.Append(splittedString[1]);
			builder.Append("]");

			return builder.ToString();
		}
	}
}