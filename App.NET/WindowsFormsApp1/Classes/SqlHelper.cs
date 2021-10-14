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

		public static IList<string> GetTables(string queryString, string connectionString)
		{
			var tables = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader =  command.ExecuteReader();
				try
				{
					while (reader.Read())
					{
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

		public static DataSet GetTableDataSet(string name)
		{
			DataSet ds = new DataSet();

			using (SqlConnection connection = new SqlConnection(connString))
			{
				connection.Open();
				SqlDataAdapter da = new SqlDataAdapter();
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandText = SqlScripts.SelectScript + "[" + name + "]";
				da.SelectCommand = cmd;
				da.Fill(ds);
			}

			return ds;
		}

		public static void SaveAndCommitToDb(DataSet dataset, string currentTable)
		{
			using (SqlConnection conn = new SqlConnection(SqlHelper.connString))
			{
				conn.Open();

				DataSet newDataSet = new DataSet();
				SqlDataAdapter newDataAdapter = new SqlDataAdapter();
				newDataAdapter.SelectCommand = new SqlCommand(SqlScripts.SelectScript + $"[{currentTable}]", conn);
				SqlCommandBuilder cb = new SqlCommandBuilder(newDataAdapter);
				newDataAdapter.Fill(newDataSet);

				newDataAdapter.UpdateCommand = cb.GetUpdateCommand();
				newDataAdapter.Update(dataset, dataset.Tables[0].TableName);
				
				conn.Close();
			}
		}
	}
}
