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

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		private App app = new App();

		DataSet dataset = new DataSet();
		string currentTable;
		bool isLoaded = false;

		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			InitializeTree();
		}

		private void InitializeTree()
		{
			var rootItems = SqlHelper.GetTables(SqlScripts.SelectTables, SqlHelper.connString);

			try
			{
				treeView1.BeginUpdate();
				treeView1.Nodes.Add(CreateNodesForTables(rootItems));
				treeView1.Nodes.Add(CreateNodesForReports(rootItems));
			}
			finally
			{
				treeView1.EndUpdate();
			};
		}

		private TreeNode CreateNodesForTables(IList<string> items)
		{
			var node = new TreeNode() { Text = "Tables" };

			//TODO: For this demo we're just going assign the key of the item to the node but you could store anything
			node.Tag = 0;

			//TODO: Going with the fast option so we'll create a dummy node
			foreach(var item in items)
			{
				var child = new TreeNode() { Text = item };
				node.Nodes.Add(child);
			}

			return node;
		}

		//rework for reports
		private TreeNode CreateNodesForReports(IList<string> items)
		{
			var node = new TreeNode() { Text = "Reports" };

			node.Tag = 1;

			//foreach (var item in items)
			//{
			//	var child = new TreeNode() { Text = item };
			//	node.Nodes.Add(child);
			//}

			return node;
		}

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			Console.Write(e.Node.Parent);
			if (e.Node.Parent?.ToString() == "TreeNode: Tables")
			{
				isLoaded = false;
				currentTable = e.Node.Text;
				InitializeDataSet(e.Node.Text);
			}
			isLoaded = true;
			InitializeCombo();
		}

		private void InitializeCombo()
		{
			var ds = (DataSet)dataGridView1?.DataSource;
			string[] columnNames = ds?.Tables[0]?.Columns.Cast<DataColumn>()
								 .Select(x => x.ColumnName)
								 .ToArray();
			if(columnNames != null)
				comboBox1.Items.AddRange(columnNames);
		}

		private void InitializeDataSet(string tableName)
		{
			dataset = SqlHelper.GetTableDataSet(tableName);

			dataGridView1.DataSource = null;
			dataGridView1.AutoGenerateColumns = true;
			dataGridView1.DataSource = dataset;
			dataGridView1.DataMember = dataset.Tables[0].TableName;
		}

		private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{

		}

		private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			if(isLoaded)
			{

			}
		}

		private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (isLoaded)
			{

			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (dataGridView1?.DataSource != null)
			{
				DataSet ds = (DataSet)dataGridView1.DataSource;
				if (ds.HasChanges())
				{
					try
					{
						SqlHelper.SaveAndCommitToDb((DataSet)dataGridView1.DataSource, currentTable);
					}
					catch (SqlException ex)
					{
						app.LogError(ex);
					}
				}
			}
		}

		//search dont work
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (dataGridView1?.DataSource != null)
				{
					var tempTable = (DataSet)dataGridView1.DataSource;
					tempTable.Tables[0].DefaultView.RowFilter = string.Format("" + comboBox1.Text + " like '%{0}%'", textBox1.Text.Trim().Replace("'", "''"));
					dataGridView1.DataSource = tempTable;
				}
			}
			catch(Exception ex)
			{
				app.LogError(ex);
			}
		}
	}
}
