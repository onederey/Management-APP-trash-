using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		private App app = new App();

		DataSet dataset = new DataSet();
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
			var rootItems = SqlHelper.GetTables(SqlScripts.SelectTables);
			var rootItemsForReports = SqlHelper.GetReports(SqlScripts.SelectReports);
			var rootItemsForViews = SqlHelper.GetViews(SqlScripts.SelectViews);

			try
			{
				treeView1.BeginUpdate();
				treeView1.Nodes.Add(CreateNodesForTables(rootItems));
				treeView1.Nodes.Add(CreateNodesForReports(rootItemsForReports));
				treeView1.Nodes.Add(CreateNodesForViews(rootItemsForViews));
			}
			finally
			{
				treeView1.EndUpdate();
			};
		}

		private TreeNode CreateNodesForViews(IList<string> items)
		{
			var node = new TreeNode() { Text = "Views" };
			node.Tag = 0;
			foreach (var item in items)
			{
				var child = new TreeNode() { Text = item };
				node.Nodes.Add(child);
			}

			return node;
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

		private TreeNode CreateNodesForReports(IList<string> items)
		{
			var node = new TreeNode() { Text = "Reports" };

			node.Tag = 1;

			foreach (var item in items)
			{
				var child = new TreeNode() { Text = item };
				node.Nodes.Add(child);
			}

			return node;
		}

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox1.Text="Filter";
			textBox1.Clear();
            textBox1.Text = "Search...";

			if (e.Node.Parent?.ToString() == "TreeNode: Tables" || e.Node.Parent?.ToString() == "TreeNode: Views")
            {
				currentTable = e.Node.Text;
				InitializeDataSet(e.Node.Text, e.Node.Parent?.ToString() == "TreeNode: Tables" ? false : true);
			}
			InitializeCombo();

			if (e.Node.Parent?.ToString() == "TreeNode: Reports")
			{
				Form reportForm = new ReportFor_m(e.Node.Text);
				reportForm.TopMost = true;
				reportForm.Show();
			}
		}

		private void InitializeCombo()
		{
            dataGridView1.CurrentCell = null;
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

		private void InitializeDataSet(string tableName, bool isView = false)
		{
			dataset = SqlHelper.GetTableDataSet(tableName);

            this.Text = tableName;
			dataGridView1.DataSource = null;
			dataGridView1.AutoGenerateColumns = true;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.DataSource = dataset;
			dataGridView1.DataMember = dataset.Tables[0].TableName;
			dataGridView1.ReadOnly = isView;
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

                if (dataGridView1.CurrentRow?.Index != default)
                {
                    var temp = dataGridView1.CurrentRow.Index;
                    InitializeDataSet(currentTable);
                    dataGridView1.FirstDisplayedScrollingRowIndex = temp;
                    dataGridView1.Rows[temp].Selected = true;
				}
                
            }
			
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text;
            string searchRowName = comboBox1.Text;
			
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int rowIndex = row.Index;
                dataGridView1.Rows[rowIndex].Visible = true;
            }
			
			if (dataGridView1 != null && dataGridView1?.DataSource != null)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = 0;
				dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (dataGridView1.Columns[row.Cells[i].ColumnIndex].HeaderText == searchRowName)
                            {
                                if (row.Cells[i].Value == null || !(row.Cells[i].Value.ToString().ToUpper().StartsWith(searchValue.ToUpper())))
                                {
                                    int rowIndex = row.Index;
                                    dataGridView1.Rows[rowIndex].Visible = false;
                                    break;
                                }
                            }
                        }
						
                        if (row.Index == dataGridView1.Rows.Count - 2)
                            break;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }

        }   

        private void textBox1_Click(object sender, EventArgs e)
        {
			if(textBox1.Text == "Search...")
			    textBox1.Clear();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Text = "";
        }
    }
}
