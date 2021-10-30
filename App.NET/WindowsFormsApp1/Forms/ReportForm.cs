using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

		public ReportFor_m(string report)
		{
			InitializeComponent();
			currentReport = report;
			UpdateReportData();
		}

		private void UpdateReportData()
		{

		}

		private string GetReportSP() => SqlHelper.GetReportSP(currentReport);
	}
}
