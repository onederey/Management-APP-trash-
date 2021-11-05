using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1.Forms
{
	public partial class ReportFor_m : Form
	{
		private string currentReport;
		private int paramsCount = 0;

		public ReportFor_m(string report)
		{
			InitializeComponent();
			currentReport = report;
			this.Text = currentReport;
			paramsCount = 0;
			HideParamsBoxes();
			UpdateReportData();
		}

		private void HideParamsBoxes()
		{
			//panel1.Visible = false;
			label1.Visible = false;

			textBoxParam1.Visible = false;
			textBoxParam2.Visible = false;
			textBoxParam3.Visible = false;

			paramLabel1.Visible = false;
			paramLabel2.Visible = false;
			paramLabel3.Visible = false;
		}

		private void UpdateReportData()
		{
			var paramSP = GetReportParams().Tables[0].Rows;
			switch (paramSP.Count)
			{
				case 0:
					break;
				case 1:
					textBoxParam1.Visible = true;
					paramLabel1.Visible = true;
					paramLabel1.Text = paramSP[0].ItemArray[1].ToString() + " (" + paramSP[0].ItemArray[2].ToString() + "):";
					paramsCount++;
					break;
				case 2:
					textBoxParam1.Visible = true;
					paramLabel1.Visible = true;
					paramLabel1.Text = paramSP[0].ItemArray[1].ToString() + " (" + paramSP[0].ItemArray[2].ToString() + "):";
					paramsCount++;

					textBoxParam2.Visible = true;
					paramLabel2.Visible = true;
					paramLabel2.Text = paramSP[1].ItemArray[1].ToString() + " (" + paramSP[1].ItemArray[2].ToString() + "):";
					paramsCount++;
					break;
				case 3:
					textBoxParam1.Visible = true;
					paramLabel1.Visible = true;
					paramLabel1.Text = paramSP[0].ItemArray[1].ToString() + " (" + paramSP[0].ItemArray[2].ToString() + "):";
					paramsCount++;

					textBoxParam2.Visible = true;
					paramLabel2.Visible = true;
					paramLabel2.Text = paramSP[1].ItemArray[1].ToString() + " (" + paramSP[1].ItemArray[2].ToString() + "):";
					paramsCount++;

					textBoxParam3.Visible = true;
					paramLabel3.Visible = true;
					paramLabel3.Text = paramSP[2].ItemArray[1].ToString() + " (" + paramSP[2].ItemArray[2].ToString() + "):";
					paramsCount++;
					break;
				default:
					break;
			}
		}

		//shit
		private string GetReportSP() => SqlHelper.GetReportSP(currentReport);

		//guess same shit
		private DataSet GetReportParams() => SqlHelper.GetSPParams(GetReportSP());

		/// <summary>
		/// CREATE REPORT
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				SqlParameter param1 = new SqlParameter();
				SqlParameter param2 = new SqlParameter();
				SqlParameter param3 = new SqlParameter();
				var ds = new DataSet();

				switch (paramsCount)
				{
					case 0:
						break;
					case 1:
						param1 = CreateSqlParameter(paramLabel1.Text, string.IsNullOrEmpty(textBoxParam1.Text) ? null : textBoxParam1.Text);
						ds = SqlHelper.ExecSpWithParams(GetReportSP(), param1);
						break;
					case 2:
						param1 = CreateSqlParameter(paramLabel1.Text, string.IsNullOrEmpty(textBoxParam1.Text) ? null : textBoxParam1.Text);
						param2 = CreateSqlParameter(paramLabel2.Text, string.IsNullOrEmpty(textBoxParam2.Text) ? null : textBoxParam2.Text);
						ds = SqlHelper.ExecSpWithParams(GetReportSP(), param1, param2);
						break;
					case 3:
						param1 = CreateSqlParameter(paramLabel1.Text, string.IsNullOrEmpty(textBoxParam1.Text) ? null : textBoxParam1.Text);
						param2 = CreateSqlParameter(paramLabel2.Text, string.IsNullOrEmpty(textBoxParam2.Text) ? null : textBoxParam2.Text);
						param3 = CreateSqlParameter(paramLabel3.Text, string.IsNullOrEmpty(textBoxParam3.Text) ? null : textBoxParam3.Text);
						ds = SqlHelper.ExecSpWithParams(GetReportSP(), param1, param2, param3);
						break;
					default:
						break;
				}

				if (ds != default)
				{
					dataGridView1.DataSource = null;
					dataGridView1.AutoGenerateColumns = true;
					dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
					dataGridView1.DataSource = ds;
					dataGridView1.DataMember = ds.Tables?[0].TableName;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show($"OK)( {ex.Message}");
			}
		}

		private SqlParameter CreateSqlParameter(string param, object value)
		{
			SqlParameter parameter = new SqlParameter();
			var splitParam = param.Split(' ');
			parameter.ParameterName = splitParam[0];
			parameter.Value = value;

			if (splitParam[1].Contains("DATE"))
				parameter.SqlDbType = SqlDbType.Date;
			else if (splitParam[1].Contains("SMALLINT"))
				parameter.SqlDbType = SqlDbType.SmallInt;
			else if (splitParam[1].Contains("INT"))
				parameter.SqlDbType = SqlDbType.Int;
			else if (splitParam[1].Contains("NVARCHAR"))
				parameter.SqlDbType = SqlDbType.NVarChar;

			return parameter;
		}

		/// <summary>
		/// EXPORT TO PDF
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exportButton_Click(object sender, EventArgs e)
		{

		}
	}
}
