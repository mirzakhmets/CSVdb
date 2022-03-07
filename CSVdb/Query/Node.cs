/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/6/2022
 * Time: 5:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using CSVdb.Db;

namespace CSVdb.Query
{
	/// <summary>
	/// Node.
	/// </summary>
	public class Node
	{
		public NodeType type;
		public Node left, right;
		public string stringValue;
		public double realValue;
		public string field;
		
		public Node(NodeType type)
		{
			this.type = type;
		}
		
		public string getValue(Node node, Cursor cursor) {
			if (node.type == NodeType.CONST_NUMBER) {
				return "" + node.realValue;
			}
			
			if (node.type == NodeType.CONST_STRING) {
				return node.stringValue;
			}
			
			if (node.type == NodeType.FIELD) {
				string[] a = node.field.Split(new char[] { '.' });
				
				Table t = cursor.database.getTable(a[0]);
				
				Row r = (Row) t.rows[cursor.index[t.databaseIndex]];
				
				return ((Column) r.columns[t.namesIndex[a[1]]]).value;
			}
			
			return null;
		}
		
		public static int compare(string a, string b) {
			double c, d;
			
			if (Double.TryParse(a, out c) && Double.TryParse(b, out d)) {
				if (c == d) {
					return 0;
				}
				
				return c < d ? -1: 1;
			}
			
			return a.CompareTo(b);
		}
		
		public bool accepts(Cursor cursor) {
			switch (this.type) {
				case NodeType.AND: {
					return this.left.accepts(cursor) && this.right.accepts(cursor);
				}
				case NodeType.OR: {
					return this.left.accepts(cursor) || this.right.accepts(cursor);
				}
				case NodeType.NOT: {
					return !this.left.accepts(cursor);
				}
				case NodeType.GROUP: {
					return this.left.accepts(cursor);
				}
				case NodeType.EQ: {
					return compare(this.left.getValue(this.left, cursor), this.right.getValue(this.right, cursor)) == 0;
				}
				case NodeType.LESS: {
					return compare(this.left.getValue(this.left, cursor), this.right.getValue(this.right, cursor)) < 0;
				}
				case NodeType.GREATER: {
					return compare(this.left.getValue(this.left, cursor), this.right.getValue(this.right, cursor)) > 0;
				}
			}
			
			return true;
		}
	}
}
