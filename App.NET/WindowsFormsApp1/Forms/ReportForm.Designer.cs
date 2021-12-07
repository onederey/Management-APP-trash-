namespace WindowsFormsApp1.Forms
{
	partial class ReportFor_m
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
			this.exportButton = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.paramLabel3 = new System.Windows.Forms.Label();
			this.textBoxParam3 = new System.Windows.Forms.TextBox();
			this.paramLabel2 = new System.Windows.Forms.Label();
			this.textBoxParam2 = new System.Windows.Forms.TextBox();
			this.paramLabel1 = new System.Windows.Forms.Label();
			this.textBoxParam1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// exportButton
			// 
			this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.exportButton.Location = new System.Drawing.Point(669, 416);
			this.exportButton.Name = "exportButton";
			this.exportButton.Size = new System.Drawing.Size(151, 23);
			this.exportButton.TabIndex = 1;
			this.exportButton.Text = "Export to PDF";
			this.exportButton.UseVisualStyleBackColor = true;
			this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.GridColor = System.Drawing.Color.WhiteSmoke;
			this.dataGridView1.Location = new System.Drawing.Point(232, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(588, 395);
			this.dataGridView1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(12, 416);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(151, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Create report";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.paramLabel3);
			this.panel1.Controls.Add(this.textBoxParam3);
			this.panel1.Controls.Add(this.paramLabel2);
			this.panel1.Controls.Add(this.textBoxParam2);
			this.panel1.Controls.Add(this.paramLabel1);
			this.panel1.Controls.Add(this.textBoxParam1);
			this.panel1.Location = new System.Drawing.Point(12, 30);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(214, 376);
			this.panel1.TabIndex = 4;
			// 
			// paramLabel3
			// 
			this.paramLabel3.AutoSize = true;
			this.paramLabel3.Location = new System.Drawing.Point(3, 112);
			this.paramLabel3.Name = "paramLabel3";
			this.paramLabel3.Size = new System.Drawing.Size(124, 13);
			this.paramLabel3.TabIndex = 10;
			this.paramLabel3.Text = "Fill parameters of Report!";
			// 
			// textBoxParam3
			// 
			this.textBoxParam3.Location = new System.Drawing.Point(0, 128);
			this.textBoxParam3.Name = "textBoxParam3";
			this.textBoxParam3.Size = new System.Drawing.Size(214, 20);
			this.textBoxParam3.TabIndex = 9;
			// 
			// paramLabel2
			// 
			this.paramLabel2.AutoSize = true;
			this.paramLabel2.Location = new System.Drawing.Point(3, 61);
			this.paramLabel2.Name = "paramLabel2";
			this.paramLabel2.Size = new System.Drawing.Size(124, 13);
			this.paramLabel2.TabIndex = 8;
			this.paramLabel2.Text = "Fill parameters of Report!";
			// 
			// textBoxParam2
			// 
			this.textBoxParam2.Location = new System.Drawing.Point(0, 77);
			this.textBoxParam2.Name = "textBoxParam2";
			this.textBoxParam2.Size = new System.Drawing.Size(214, 20);
			this.textBoxParam2.TabIndex = 7;
			// 
			// paramLabel1
			// 
			this.paramLabel1.AutoSize = true;
			this.paramLabel1.Location = new System.Drawing.Point(3, 11);
			this.paramLabel1.Name = "paramLabel1";
			this.paramLabel1.Size = new System.Drawing.Size(124, 13);
			this.paramLabel1.TabIndex = 6;
			this.paramLabel1.Text = "Fill parameters of Report!";
			// 
			// textBoxParam1
			// 
			this.textBoxParam1.Location = new System.Drawing.Point(0, 27);
			this.textBoxParam1.Name = "textBoxParam1";
			this.textBoxParam1.Size = new System.Drawing.Size(214, 20);
			this.textBoxParam1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(56, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Fill parameters of Report!";
			// 
			// ReportFor_m
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Aquamarine;
			this.ClientSize = new System.Drawing.Size(832, 451);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.exportButton);
			this.Name = "ReportFor_m";
			this.Text = "ReportFor_m";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button exportButton;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label paramLabel3;
		private System.Windows.Forms.TextBox textBoxParam3;
		private System.Windows.Forms.Label paramLabel2;
		private System.Windows.Forms.TextBox textBoxParam2;
		private System.Windows.Forms.Label paramLabel1;
		private System.Windows.Forms.TextBox textBoxParam1;
	}
}