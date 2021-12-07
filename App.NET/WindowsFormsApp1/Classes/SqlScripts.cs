using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
	public static class SqlScripts
	{
		public static string SelectScript = "SELECT * FROM ";

		public static string SelectTables = "SELECT [TABLE_SCHEMA] + '.' +[TABLE_NAME] as [TABLE_NAME] FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

		public static string SelectReports = "SELECT [ReportName] FROM [dbo].[Reports]";

		public static string SelectReportSP = "SELECT TOP(1) [StoredProcedure] FROM [dbo].[Reports] WHERE [ReportName] =";

		public static string SelectViews = "SELECT CONCAT(OBJECT_SCHEMA_NAME([v].[object_id]), '.', [v].[name]) as [Name] FROM sys.views as [v]";

		#region SelectFK
		public static string SelectFK = @"SELECT
											OBJECT_NAME(f.parent_object_id) TableName,
											COL_NAME(fc.parent_object_id, fc.parent_column_id) ColName
										FROM
											sys.foreign_keys AS f
										INNER JOIN
											sys.foreign_key_columns AS fc ON f.OBJECT_ID = fc.constraint_object_id
										INNER JOIN
											sys.tables t ON t.OBJECT_ID = fc.referenced_object_id
										WHERE
											OBJECT_NAME(f.parent_object_id) = OBJECT_NAME(f.referenced_object_id) and
											OBJECT_NAME (f.referenced_object_id) = "; //need table name after = in ''
		#endregion

		#region SelectSPParams
		public static string SelectSPParams = @"SELECT
													pa.parameter_id AS[order]
													,pa.name AS[name]
													,UPPER(t.name) AS[type]
													,t.max_length AS[length]
												FROM
													sys.parameters AS pa
												INNER JOIN
													sys.procedures AS p on pa.object_id = p.object_id
												INNER JOIN
													sys.types AS t on pa.system_type_id = t.system_type_id AND pa.user_type_id = t.user_type_id
												WHERE
													p.name = '";
		#endregion

	}
}
