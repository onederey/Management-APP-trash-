using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
	public class App
	{
		public void LogError(Exception ex)
		{
			MessageBox.Show($@"--Exception--
								{ex}
								{ex.Message}
								--Exception--");
		}

		public void LogSuccess(string action)
		{
			MessageBox.Show($"{action} - success!");
		}
	}
}
