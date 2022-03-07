/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/6/2022
 * Time: 5:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace CSVdb.Db
{
	/// <summary>
	/// Database row.
	/// </summary>
	public class Row
	{
		public ArrayList columns = new ArrayList();
		public int rowid;
		public Table table;
		
		public Row()
		{
		}
	}
}
