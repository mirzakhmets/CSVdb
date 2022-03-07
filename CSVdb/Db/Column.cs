/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/6/2022
 * Time: 5:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CSVdb.Db
{
	/// <summary>
	/// Database column.
	/// </summary>
	public class Column
	{
		public string value = null;
		
		public Column(string value)
		{
			this.value = value;
		}
	}
}
