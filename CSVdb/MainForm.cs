/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/4/2022
 * Time: 9:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CSVdb.Db;
using CSVdb.CSV;
using CSVdb.Query;

namespace CSVdb
{
	/// <summary>
	/// MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ButtonRunClick(object sender, EventArgs e)
		{
			/*
			Database database = new Database();
			
			FileStream fs = File.Open("fruits.csv", FileMode.Open);
			
			CSVFile file = new CSVFile(new ParsingStream(fs), "Fruits");
			
			fs.Close();
			
			database.addCSVFile(file, "Fruits");
			
			fs = File.Open("stores.csv", FileMode.Open);
			
			file = new CSVFile(new ParsingStream(fs), "Stores");
			
			fs.Close();
			
			database.addCSVFile(file, "Stores");
			
			//Parser parser = new Query.Parser(new ParsingStream(new MemoryStream(System.Text.Encoding.Default.GetBytes("(a = b & c = 'aa') | d = 1.73"))));
			
			Parser parser = new Query.Parser(new ParsingStream(new MemoryStream(System.Text.Encoding.Default.GetBytes("Fruits.Fruit = 'Apple' & Stores.Distance > 25"))));
			
			Node node = parser.parse();
			
			Db.Cursor cursor = new Db.Cursor(database);
			
			Table t = cursor.run(node);
			
			int k = 0;
			*/
			
			Database database = new Database();
			
			foreach (string s in this.listBoxSource.Items) {
				FileStream fs = File.Open(s, FileMode.Open);
				
				string[] names = s.Split(new char[] { '.', '\\', '/' });
				
				CSVFile file = new CSVFile(new ParsingStream(fs), names[names.Length - 2]);
				
				fs.Close();
				
				database.addCSVFile(file, names[names.Length - 2]);
			}
			
			Parser parser = new Parser(new ParsingStream(new MemoryStream(System.Text.Encoding.Default.GetBytes(this.richTextBoxQuery.Text))));
			
			Node node = parser.parse();
			
			Db.Cursor cursor = new Db.Cursor(database);
			
			Table table = cursor.run(node);
			
			FileStream output = File.Open(this.textBoxResult.Text, FileMode.CreateNew);
			
			table.write(output);
			
			output.Close();
		}
		
		void ButtonSourceAddClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				this.listBoxSource.Items.Add(openFileDialog.FileName);
			}
		}
		
		void ButtonSourceRemoveClick(object sender, EventArgs e)
		{
			this.listBoxSource.Items.Remove(this.listBoxSource.SelectedItem);
		}
		
		void ButtonResultClick(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				this.textBoxResult.Text = saveFileDialog.FileName;
			}
		}
	}
}
