/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/6/2022
 * Time: 10:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace CSVdb
{
	/// <summary>
	/// Parsing stream.
	/// </summary>
	public class ParsingStream
	{
		public Stream stream;
		public int current = -1;
		
		public ParsingStream(Stream stream)
		{
			this.stream = stream;
			
			this.Read();
		}
		
		public void Read() {
			this.current = this.stream.ReadByte();
		}
		
		public bool atEnd() {
			return this.current == -1;
		}
		
		public void parseBlanks() {
			while (" \r\t\v".IndexOf((char) this.current) >= 0) {
				this.Read();
			}
		}
	}
}
