/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/4/2022
 * Time: 9:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;

using CSVdb.Db;

namespace CSVdb.CSV
{
	/// <summary>
	/// CSV file.
	/// </summary>
	public class CSVFile
	{
		public string name = null;
		public ArrayList names = new ArrayList();
		public Dictionary<string, int> namesIndex = new Dictionary<string, int>();
		public ArrayList lines = new ArrayList();
		
		public CSVFile(ParsingStream stream, string name)
		{
			this.name = name;
			
			CSVLine namesLine = new CSVLine(stream);
			
			int i = 0;
			
			foreach (string s in namesLine.values) {
				this.names.Add(s);
				
				this.namesIndex.Add(s, i++);
			}
			
			while (!stream.atEnd()) {
				CSVLine line = new CSVLine(stream);
				
				if (line.values.Count > 0) {
					this.lines.Add(line);
				}
			}
		}
		
		public Table toTable() {
			Table table = new Table();
			
			table.name = this.name;
			
			int i = 0;
			
			foreach (string s in this.names) {
				table.names.Add(s);
				
				table.namesIndex.Add(s, i++);
			}
			
			foreach (CSVLine line in this.lines) {
				Row row = new Row();
				
				foreach (string s in line.values) {
					row.columns.Add(new Column(s));
				}
				
				table.rows.Add(row);
				
				row.rowid = line.rowid;
				
				table.index.Add(row.rowid, row);
				
				row.table = table;
			}
			
			return table;
		}
	}
}
