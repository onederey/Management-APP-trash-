﻿namespace WindowsFormsApp1
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Save = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.BackColor = System.Drawing.Color.Azure;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(236, 518);
			this.treeView1.TabIndex = 0;
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.GridColor = System.Drawing.SystemColors.WindowText;
			this.dataGridView1.Location = new System.Drawing.Point(242, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(775, 518);
			this.dataGridView1.TabIndex = 1;
			// 
			// Save
			// 
			this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Save.Location = new System.Drawing.Point(864, 531);
			this.Save.Name = "Save";
			this.Save.Size = new System.Drawing.Size(134, 21);
			this.Save.TabIndex = 2;
			this.Save.Text = "Save";
			this.Save.UseVisualStyleBackColor = true;
			this.Save.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(12, 530);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 3;
			this.comboBox1.Text = "Filter";
			this.comboBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseClick);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox1.Location = new System.Drawing.Point(148, 531);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(187, 20);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "Search...";
			this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 554);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1010, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(1010, 576);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.Save);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.treeView1);
			this.MinimumSize = new System.Drawing.Size(1026, 604);
			this.Name = "Form1";
			this.Text = "App.NET";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button Save;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
	}
}

