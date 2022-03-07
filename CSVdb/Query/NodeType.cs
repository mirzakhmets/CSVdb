/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 3/6/2022
 * Time: 5:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CSVdb.Query
{
	/// <summary>
	/// Node type.
	/// </summary>
	public enum NodeType
	{
		AND,
		OR,
		NOT,
		GROUP,
		LESS,
		GREATER,
		//EQ_LESS,
		//EQ_GREATER,
		EQ,
		//EQ_LEFT,
		//EQ_RIGHT,
		//EQ_LR,
		FIELD,
		CONST_STRING,
		CONST_NUMBER
	}
}
