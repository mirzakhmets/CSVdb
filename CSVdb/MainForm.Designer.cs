/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/4/2022
 * Time: 9:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CSVdb
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageMain = new System.Windows.Forms.TabPage();
			this.richTextBoxQuery = new System.Windows.Forms.RichTextBox();
			this.labelQuery = new System.Windows.Forms.Label();
			this.buttonResult = new System.Windows.Forms.Button();
			this.textBoxResult = new System.Windows.Forms.TextBox();
			this.labelResult = new System.Windows.Forms.Label();
			this.buttonSourceRemove = new System.Windows.Forms.Button();
			this.buttonSourceAdd = new System.Windows.Forms.Button();
			this.listBoxSource = new System.Windows.Forms.ListBox();
			this.labelSource = new System.Windows.Forms.Label();
			this.buttonRun = new System.Windows.Forms.Button();
			this.tabPageHelp = new System.Windows.Forms.TabPage();
			this.richTextBoxHelp = new System.Windows.Forms.RichTextBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.tabControl.SuspendLayout();
			this.tabPageMain.SuspendLayout();
			this.tabPageHelp.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageMain);
			this.tabControl.Controls.Add(this.tabPageHelp);
			this.tabControl.Location = new System.Drawing.Point(2, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(342, 323);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageMain
			// 
			this.tabPageMain.Controls.Add(this.richTextBoxQuery);
			this.tabPageMain.Controls.Add(this.labelQuery);
			this.tabPageMain.Controls.Add(this.buttonResult);
			this.tabPageMain.Controls.Add(this.textBoxResult);
			this.tabPageMain.Controls.Add(this.labelResult);
			this.tabPageMain.Controls.Add(this.buttonSourceRemove);
			this.tabPageMain.Controls.Add(this.buttonSourceAdd);
			this.tabPageMain.Controls.Add(this.listBoxSource);
			this.tabPageMain.Controls.Add(this.labelSource);
			this.tabPageMain.Controls.Add(this.buttonRun);
			this.tabPageMain.Location = new System.Drawing.Point(4, 22);
			this.tabPageMain.Name = "tabPageMain";
			this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMain.Size = new System.Drawing.Size(334, 297);
			this.tabPageMain.TabIndex = 0;
			this.tabPageMain.Text = "Main";
			this.tabPageMain.UseVisualStyleBackColor = true;
			// 
			// richTextBoxQuery
			// 
			this.richTextBoxQuery.Location = new System.Drawing.Point(17, 170);
			this.richTextBoxQuery.Name = "richTextBoxQuery";
			this.richTextBoxQuery.Size = new System.Drawing.Size(306, 69);
			this.richTextBoxQuery.TabIndex = 9;
			this.richTextBoxQuery.Text = "Fruits.Fruit = \'Apple\' & Stores.Distance > 25";
			// 
			// labelQuery
			// 
			this.labelQuery.Location = new System.Drawing.Point(17, 152);
			this.labelQuery.Name = "labelQuery";
			this.labelQuery.Size = new System.Drawing.Size(51, 15);
			this.labelQuery.TabIndex = 8;
			this.labelQuery.Text = "Query:";
			// 
			// buttonResult
			// 
			this.buttonResult.Location = new System.Drawing.Point(289, 119);
			this.buttonResult.Name = "buttonResult";
			this.buttonResult.Size = new System.Drawing.Size(35, 20);
			this.buttonResult.TabIndex = 7;
			this.buttonResult.Text = "...";
			this.buttonResult.UseVisualStyleBackColor = true;
			this.buttonResult.Click += new System.EventHandler(this.ButtonResultClick);
			// 
			// textBoxResult
			// 
			this.textBoxResult.Location = new System.Drawing.Point(17, 119);
			this.textBoxResult.Name = "textBoxResult";
			this.textBoxResult.Size = new System.Drawing.Size(266, 20);
			this.textBoxResult.TabIndex = 6;
			// 
			// labelResult
			// 
			this.labelResult.Location = new System.Drawing.Point(17, 100);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size(76, 16);
			this.labelResult.TabIndex = 5;
			this.labelResult.Text = "Result:";
			// 
			// buttonSourceRemove
			// 
			this.buttonSourceRemove.Location = new System.Drawing.Point(289, 63);
			this.buttonSourceRemove.Name = "buttonSourceRemove";
			this.buttonSourceRemove.Size = new System.Drawing.Size(35, 24);
			this.buttonSourceRemove.TabIndex = 4;
			this.buttonSourceRemove.Text = "-";
			this.buttonSourceRemove.UseVisualStyleBackColor = true;
			this.buttonSourceRemove.Click += new System.EventHandler(this.ButtonSourceRemoveClick);
			// 
			// buttonSourceAdd
			// 
			this.buttonSourceAdd.Location = new System.Drawing.Point(289, 31);
			this.buttonSourceAdd.Name = "buttonSourceAdd";
			this.buttonSourceAdd.Size = new System.Drawing.Size(35, 25);
			this.buttonSourceAdd.TabIndex = 3;
			this.buttonSourceAdd.Text = "+";
			this.buttonSourceAdd.UseVisualStyleBackColor = true;
			this.buttonSourceAdd.Click += new System.EventHandler(this.ButtonSourceAddClick);
			// 
			// listBoxSource
			// 
			this.listBoxSource.FormattingEnabled = true;
			this.listBoxSource.Items.AddRange(new object[] {
									"Fruits.csv",
									"Stores.csv"});
			this.listBoxSource.Location = new System.Drawing.Point(17, 31);
			this.listBoxSource.Name = "listBoxSource";
			this.listBoxSource.Size = new System.Drawing.Size(266, 56);
			this.listBoxSource.TabIndex = 2;
			// 
			// labelSource
			// 
			this.labelSource.Location = new System.Drawing.Point(17, 14);
			this.labelSource.Name = "labelSource";
			this.labelSource.Size = new System.Drawing.Size(57, 14);
			this.labelSource.TabIndex = 1;
			this.labelSource.Text = "Source:";
			// 
			// buttonRun
			// 
			this.buttonRun.Location = new System.Drawing.Point(119, 257);
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.Size = new System.Drawing.Size(89, 26);
			this.buttonRun.TabIndex = 0;
			this.buttonRun.Text = "Run";
			this.buttonRun.UseVisualStyleBackColor = true;
			this.buttonRun.Click += new System.EventHandler(this.ButtonRunClick);
			// 
			// tabPageHelp
			// 
			this.tabPageHelp.Controls.Add(this.richTextBoxHelp);
			this.tabPageHelp.Location = new System.Drawing.Point(4, 22);
			this.tabPageHelp.Name = "tabPageHelp";
			this.tabPageHelp.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageHelp.Size = new System.Drawing.Size(334, 297);
			this.tabPageHelp.TabIndex = 1;
			this.tabPageHelp.Text = "Help";
			this.tabPageHelp.UseVisualStyleBackColor = true;
			// 
			// richTextBoxHelp
			// 
			this.richTextBoxHelp.Location = new System.Drawing.Point(6, 6);
			this.richTextBoxHelp.Name = "richTextBoxHelp";
			this.richTextBoxHelp.ReadOnly = true;
			this.richTextBoxHelp.Size = new System.Drawing.Size(322, 285);
			this.richTextBoxHelp.TabIndex = 0;
			this.richTextBoxHelp.Text = "\n\"&\" - logical AND\n\n\"|\" - logical OR\n\n\"~\" - logical NOT\n\n\"( )\" - grouping\n\n\"<\" - " +
			"less\n\n\">\" - greater\n\n\"=\" - equal\n\n\"<table>.<column>\" - field\n\n\" \'...\' \" - string" +
			"\n\n#.##... - number";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			this.openFileDialog.Filter = "CSV | *.csv";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "CSV | *.csv";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(346, 320);
			this.Controls.Add(this.tabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "CSVdb";
			this.tabControl.ResumeLayout(false);
			this.tabPageMain.ResumeLayout(false);
			this.tabPageMain.PerformLayout();
			this.tabPageHelp.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.RichTextBox richTextBoxHelp;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.RichTextBox richTextBoxQuery;
		private System.Windows.Forms.Label labelQuery;
		private System.Windows.Forms.TextBox textBoxResult;
		private System.Windows.Forms.Button buttonResult;
		private System.Windows.Forms.Label labelResult;
		private System.Windows.Forms.ListBox listBoxSource;
		private System.Windows.Forms.Button buttonSourceAdd;
		private System.Windows.Forms.Button buttonSourceRemove;
		private System.Windows.Forms.Label labelSource;
		private System.Windows.Forms.Button buttonRun;
		private System.Windows.Forms.TabPage tabPageHelp;
		private System.Windows.Forms.TabPage tabPageMain;
		private System.Windows.Forms.TabControl tabControl;
	}
}
