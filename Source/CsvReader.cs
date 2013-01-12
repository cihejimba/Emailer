//
// File: CsvReader.cs
//
// Author: Corey Prophitt <prophitt.corey@gmail.com>
//
// Copyright: See the readme.
//


using System;
using System.Collections.Generic;
using System.Linq;


namespace Emailer
{
	//
	// This is quite the naive parser..  
	//

	class CsvReader : FileReader
	{

		public CsvReader( string filename ) 
			: base(filename) 
		{
			
		}

		new public List<string> Read()
		{
			List<string> stringList = base.Read();
			List<string> commalessList = new List<string>();

			foreach (var line in stringList)
			{
				string newLine = line.Replace(",", "").Trim();
				Console.WriteLine(string.Format("INFO: Removing comma from {0}.", line), Color.Yellow);
				commalessList.Add(newLine);
			}

			return commalessList;
		}
	}
}
