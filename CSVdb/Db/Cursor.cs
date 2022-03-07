/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/7/2022
 * Time: 9:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using CSVdb.CSV;
using CSVdb.Query;

namespace CSVdb.Db
{
	/// <summary>
	/// Database cursor.
	/// </summary>
	public class Cursor
	{
		public Database database;
		public Table[] tables;
		public int[] index;
		public Dictionary<string, int> names = new Dictionary<string, int>();
		
		public Cursor(Database database)
		{
			this.database = database;
			
			this.tables = new Table[this.database.files.Count];
			
			this.index = new int[this.database.files.Count];
			
			int i = 0;
			
			foreach (CSVFile file in this.database.files) {
				this.index[i] = 0;
				
				this.tables[i] = file.toTable();
				
				i++;
			}
		}
		
		public bool atEnd() {
			for (int i = 0; i < this.index.Length; ++i) {
				if (this.index[i] != 0) {
					return false;
				}
			}
			
			return true;
		}
		
		public void increment() {
			for (int i = this.index.Length - 1; i >= 0; --i) {
				if (++this.index[i] >= this.tables[i].rows.Count) {
					this.index[i] = 0;
				} else {
					break;
				}
			}
		}
		
		public Table run(Node node) {
			Table table = new Table();
			
			int indexColumn = 0;
			
			for (int i = 0; i < this.index.Length; ++i) {
				Table t = (Table) this.database.tables[i];
				
				foreach (string name in t.names) {
					this.names.Add(t.name + "." + name, indexColumn++);
				}
			}
			
			indexColumn = 0;
			
			foreach (string s in this.names.Keys) {
				table.names.Add(s);
				
				table.namesIndex.Add(s, indexColumn++);
			}
			
			do {
				if (node.accepts(this)) {
					Row row = new Row();
					
					for (int i = 0; i < this.index.Length; ++i) {
						Row r = (Row) this.tables[i].rows[this.index[i]];
						
						foreach (Column column in r.columns) {
							row.columns.Add(column);
						}
					}
					
					table.rows.Add(row);
				}
				
				this.increment();
			} while (!this.atEnd());

			return table;			
		}
	}
}
