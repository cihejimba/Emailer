//
// File: FileReader.cs
//
// Author: Corey Prophitt <prophitt.corey@gmail.com>
//
// Copyright: See the readme.
//

#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

#endregion

namespace Emailer
{
	class FileReader
    {

        #region Member Variables

        private readonly string _filename;

        #endregion

        #region Creation & Destruction

        public FileReader()
		{
			
		}

		public FileReader(string filename)
		{
			_filename = filename;
		}

        #endregion

        #region Methods

        public List<string> Read()
		{
			if (_filename == null || _filename == string.Empty)
			{
				Console.WriteLine("ERROR: Filename was null or empty.", Color.Red);
				return null;
			}

			List<string> stringList = new List<string>();
			try
			{
				// Create an instance of StreamReader to read from a file.
				// The using statement also closes the StreamReader.
				using (StreamReader sr = new StreamReader(_filename))
				{
					string line;
					// Read and display lines from the file until the end of
					// the file is reached.
					while ((line = sr.ReadLine()) != null)
					{
						stringList.Add(line);
						Console.WriteLine(string.Format("INFO: Extracting a line from the file => {0}", line), Color.Green);
					}
				}
			}
			catch (Exception e)
			{
				// Let the user know what went wrong.
				Console.WriteLine("ERROR: Caught an exception while reading the file.", Color.Red);
				Console.WriteLine(e.Message, Color.Red);
			}
			return stringList;
        }

        #endregion

    } // end class FileReader
} // end namespace