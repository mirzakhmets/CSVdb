/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/4/2022
 * Time: 9:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace CSVdb.CSV
{
	/// <summary>
	/// CSV line.
	/// </summary>
	public class CSVLine
	{
		public static int ROW_ID = -1;
		
		public ArrayList values = new ArrayList();
		public int rowid;
		
		public CSVLine(ParsingStream stream)
		{
			while (!stream.atEnd()) {
				string result = parseValue(stream);
				
				if (result.Length > 0) {
					this.values.Add(result);
				}
				
				if (stream.current == '\n') {
					stream.Read();
					
					break;
				}
			}
			
			this.rowid = ++ROW_ID;
		}
		
		public string parseValue(ParsingStream stream) {
			string result = "";
			
			stream.parseBlanks();
			
			int delimeter = -1;
			
			if (stream.current == '"' || stream.current == '\'') {
				delimeter = stream.current;
				
				stream.Read();
			}
			
			if (delimeter == -1) {
				while (!stream.atEnd() && ",;".IndexOf((char) stream.current) == -1 && stream.current != '\n') {
					if (stream.current == '\\') {
						stream.Read();
						
						result += (char) stream.current;	
					} else {
						result += (char) stream.current;
					}
					
					stream.Read();
				}
			} else {
				while (!stream.atEnd() && stream.current != '\n' && stream.current != delimeter && ",;".IndexOf((char) stream.current) == -1) {
					if (stream.current == '\\') {
						stream.Read();
						
						result += (char) stream.current;
					} else {
						result += (char) stream.current;
					}
					
					stream.Read();
				}
				
				if (stream.current == delimeter) {
					stream.Read();
				}
			}
			
			stream.parseBlanks();
			
			if (",; \t".IndexOf((char) stream.current) >= 0) {
				stream.Read();
			}
			
			stream.parseBlanks();
			
			return result.Trim();
		}
	}
}
