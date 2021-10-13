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

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
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
			var rootItems = SqlHelper.GetTables("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", SqlHelper.connString);

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
			if(e.Node.Parent?.ToString() == "TreeNode: Tables")
				InitializeDataSet(e.Node.Text);
		}

		private void InitializeDataSet(string tableName)
		{
			dataGridView1.DataSource = null;
			dataGridView1.AutoGenerateColumns = true;
			dataGridView1.DataSource = SqlHelper.GetTableDataSet(tableName); // dataset
			dataGridView1.DataMember = tableName; // table name you need to show
		}
	}
}
