/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/6/2022
 * Time: 7:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using CSVdb.Db;

namespace CSVdb.Query
{
	/// <summary>
	/// Description of Result.
	/// </summary>
	public class Result
	{
		public Database database;
		public Dictionary<int, Row> rowids = new Dictionary<int, Row>();
		
		public Result(Database database)
		{
			this.database = database;
		}
		
		public void imply() {
			this.imply(this.database);
		}
		
		public void imply(Database database) {
			foreach (Table t in database.tables) {
				this.imply(t);
			}
		}
		
		public void imply(Table table) {
			foreach (Row row in table.rows) {
				this.rowids.Add(row.rowid, row);
			}
		}
	}
}
