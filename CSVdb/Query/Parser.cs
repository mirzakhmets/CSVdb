/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/6/2022
 * Time: 5:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CSVdb.Query
{
	/// <summary>
	/// Parser.
	/// </summary>
	public class Parser
	{
		public ParsingStream stream;
		
		public Parser(ParsingStream stream)
		{
			this.stream = stream;
		}
		
		public void parseBlanks() {
			while (!this.stream.atEnd() && " \r\n\t\v".IndexOf((char) this.stream.current) >= 0) {
				this.stream.Read();
			}
		}
		
		public Node parseNode() {
			this.parseBlanks();
			
			if (this.stream.atEnd()) {
				return null;
			}
			
			Node result = null;
			
			if (this.stream.current == '(') {
				result = this.parseGroup();
			} else if (this.stream.current == '"' || this.stream.current == '\'') {
				result = this.parseConstString();
			} else if ("0123456789".IndexOf((char) this.stream.current) >= 0) {
				result = this.parseConstNumber();
			} else if (this.stream.current == (char) '~') {
				result = this.parseNot();
			} else {
				result = this.parseField();
			}
			
			return result;
		}
		
		public Node parseNot() {
			Node result = null;
			
			if (this.stream.current == '~') {
				this.stream.Read();
				
				Node node = this.parseNode();
				
				result = new Node(NodeType.NOT);
				
				result.left = node;
			}
			
			return result;
		}
		
		public Node parseField() {
			Node result = null;
			
			string s = "";
			
			while (!this.stream.atEnd() && "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_.".IndexOf((char) this.stream.current) >= 0) {
				s += (char) this.stream.current;
				
				this.stream.Read();
			}
			
			if (s.Length > 0) {
				result = new Node(NodeType.FIELD);
				
				result.field = s;
			}
			
			return result;
		}
		
		public Node parseConstNumber() {
			Node result = null;
			
			string s = "";
			
			while (!this.stream.atEnd() && "0123456789.e+-E".IndexOf((char) this.stream.current) >= 0) {
				s += (char) this.stream.current;
				
				this.stream.Read();
			}
			
			if (s.Length > 0) {
				double d;
				
				if (Double.TryParse(s, out d)) {
					result = new Node(NodeType.CONST_NUMBER);
					
					result.realValue = d;
				}
			}
			
			return result;
		}
		
		public Node parseConstString() {
			Node result = null;
			
			if (this.stream.current == '"' || this.stream.current == '\'') {
				int delimeter = (char) this.stream.current;
				
				this.stream.Read();
				
				string s = "";
				
				while (!this.stream.atEnd() && this.stream.current != delimeter) {
					s += (char) this.stream.current;
					
					this.stream.Read();
				}
				
				if (this.stream.current == delimeter) {
					this.stream.Read();
				}
				
				result = new Node(NodeType.CONST_STRING);
				
				result.stringValue = s;
			}
			
			return result;
		}
		
		public Node parseGroup() {
			if (this.stream.current == '(') {
				this.stream.Read();
				
				this.parseBlanks();
				
				Node node = this.parse();
				
				if (this.stream.current == ')') {
					this.stream.Read();
				}
				
				if (node != null) {
					Node group = new Node(NodeType.GROUP);
					
					group.left = node;
					
					return group;
				}
				
				return node;
			}
			
			return null;
		}
		
		public Node parseEq() {
			Node left = this.parseNode();
			Node right = null;
			
			NodeType type = NodeType.EQ;
			
			this.parseBlanks();
			
			if (this.stream.current == '=') {
				this.stream.Read();
				
				right = this.parseNode();
			} else if (this.stream.current == '<') {
				this.stream.Read();
				
				right = this.parseNode();
				
				type = NodeType.LESS;
			} else if (this.stream.current == '>') {
				this.stream.Read();
				
				right = this.parseNode();
				
				type = NodeType.GREATER;
			}
			
			if (left == null) {
				return right;
			}
			
			if (right == null) {
				return left;
			}
			
			Node result = new Node(type);
			
			result.left = left;
			
			result.right = right;
			
			return result;
		}
		
		public bool isMeta() {
			return !this.stream.atEnd() && ")|&.~=\"'0123456789+-eE".IndexOf((char) this.stream.current) >= 0;
		}
		
		public Node parseOr() {
			Node node = this.parseEq();
			
			this.parseBlanks();
			
			if (node != null && (!this.isMeta() || this.stream.current == (char) '|')) {
				this.stream.Read();
				
				Node right = this.parseOr();
				
				if (right != null) {
					Node result = new Node(NodeType.OR);
					
					result.left = node;
					
					result.right = right;
					
					return result;
				}
			}
			
			return node;
		}
		
		public Node parseAnd() {
			Node node = this.parseOr();
			
			this.parseBlanks();
			
			if (node != null && (!this.isMeta() || this.stream.current == (char) '&')) {
				this.stream.Read();
				
				Node right = this.parseAnd();
				
				if (right != null) {
					Node result = new Node(NodeType.AND);
					
					result.left = node;
					
					result.right = right;
					
					return result;
				}
			}
			
			return node;
		}
		
		public Node parse() {
			return this.parseAnd();
		}
	}
}
