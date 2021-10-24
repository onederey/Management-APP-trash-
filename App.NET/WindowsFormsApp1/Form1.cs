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
		DataSet newDataSet = new DataSet();
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
			node.Tag = 0;
			foreach (var item in items)
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
			if (columnNames != null)
			{
				comboBox1.Items.Clear();
				comboBox1.Items.AddRange(columnNames);
			}
		}

		private void InitializeDataSet(string tableName)
		{
			dataset = SqlHelper.GetTableDataSet(tableName);

			dataGridView1.DataSource = null;
			dataGridView1.AutoGenerateColumns = true;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
			if (isLoaded)
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
						app.LogSuccess("Save to DB");
					}
					catch (SqlException ex)
					{
						app.LogError(ex);
					}
				}
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			string searchValue = textBox1.Text;
			string searchRowName = comboBox1.Text;

			if (dataGridView1 != null && dataGridView1?.DataSource != null)
			{
				if (string.IsNullOrEmpty(searchValue) || string.IsNullOrWhiteSpace(searchValue))
				{
					dataGridView1.ClearSelection();
				}
				else
				{
					dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
					try
					{
						dataGridView1.ClearSelection();

						bool valueResult = false;
						foreach (DataGridViewRow row in dataGridView1.Rows)
						{
							for (int i = 0; i < row.Cells.Count; i++)
							{
								if (row.Cells[i].Value != null && (row.Cells[i].Value.ToString().ToUpper().Contains(searchValue.ToUpper())))
								{
									if (string.IsNullOrEmpty(searchRowName) || dataGridView1.Columns[row.Cells[i].ColumnIndex].HeaderText == searchRowName)
									{
										int rowIndex = row.Index;
										dataGridView1.Rows[rowIndex].Selected = true;
										valueResult = true;
										break;
									}
								}
							}
						}

						if (!valueResult)
						{
							dataGridView1.ClearSelection();
							return;
						}
					}
					catch (Exception exc)
					{
						MessageBox.Show(exc.Message);
					}
				}
			}
		}
	}
}
