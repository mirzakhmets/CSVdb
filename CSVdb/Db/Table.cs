/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/6/2022
 * Time: 5:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace CSVdb.Db
{
	/// <summary>
	/// Database table.
	/// </summary>
	public class Table
	{
		public string name = null;
		public ArrayList rows = new ArrayList();
		public ArrayList names = new ArrayList();
		public Dictionary<string, int> namesIndex = new Dictionary<string, int>();
		public Dictionary<int, Row> index = new Dictionary<int, Row>();
		public int databaseIndex = -1;
		
		public Table()
		{
		}
		
		public void write(Stream output) {
			byte[] b;
			int i = 0;
			
			foreach (string s in this.names) {
				string t = "";
				
				if (i > 0) {
					t += ",";
				}
				
				t += "\"" + s + "\"";
				
				b = System.Text.Encoding.Default.GetBytes(t);
				
				output.Write(b, 0, b.Length);
				
				++i;
			}
			
			foreach (Row r in this.rows) {
				i = 0;
				
				b = System.Text.Encoding.Default.GetBytes("\n");
				
				output.Write(b, 0, b.Length);
				
				foreach (Column c in r.columns) {
					string t = "";
				
					if (i > 0) {
						t += ",";
					}
					
					t += c.value;
					
					b = System.Text.Encoding.Default.GetBytes(t);
					
					output.Write(b, 0, b.Length);
					
					++i;
				}
			}
		}
	}
}
