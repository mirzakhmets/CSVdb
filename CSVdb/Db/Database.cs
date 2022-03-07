/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/6/2022
 * Time: 5:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;

using CSVdb.CSV;

namespace CSVdb.Db
{
	/// <summary>
	/// Database.
	/// </summary>
	public class Database
	{
		public ArrayList files = new ArrayList();
		public ArrayList tables = new ArrayList();
		public Dictionary<string, Table> tablesIndex = new Dictionary<string, Table>();
		
		public Database()
		{
		}
		
		public Table getTable(string name) {
			if (!this.tablesIndex.ContainsKey(name)) {
				CSVFile file = null;
				
				foreach (CSVFile f in this.files) {
					if (f.name.Equals(name)) {
						file = f;
						
						break;
					}
				}
				
				if (file != null) {
					Table table = file.toTable();
					
					this.tables.Add(table);
					
					this.tablesIndex.Add(name, table);
					
					table.databaseIndex = this.tables.Count - 1;
				}
			}
			
			return this.tablesIndex[name];
		}
		
		public void addCSVFile(CSVFile file, string name) {
			this.files.Add(file);
			
			Table table = file.toTable();
			
			this.tables.Add(table);
			
			this.tablesIndex.Add(name, table);
			
			table.databaseIndex = this.tables.Count - 1;
		}
	}
}
