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
		DataSet dataset = new DataSet();
		SqlDataAdapter dataAdapter = new SqlDataAdapter();
		string currentTable;

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
				currentTable = e.Node.Text;
				InitializeDataSet(e.Node.Text);
			}
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
			SaveAndCommitToDb();
		}

		private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{

		}

		private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{

		}

		private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{

		}

		private void SaveAndCommitToDb()
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
				newDataAdapter.Update(dataset);
				
				conn.Close();
			}
		}
	}
}
