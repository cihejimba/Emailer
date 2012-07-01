//
// File: Program.cs
//
// Author: Corey Prophitt <prophitt.corey@gmail.com>
//
// Copyright: See the readme.
//


using System;
using System.Linq;


namespace Emailer
{
	enum Color
	{
		Red,
		Green,
		Yellow,
		Cyan,
		White,
	}

	class Console
	{
		public Console()
		{
			
		}

		public static void WriteLine(string message, Color color)
		{
			switch (color)
			{
				case Color.Red:
					System.Console.ForegroundColor = ConsoleColor.Red;
					break;
				case Color.Green:
					System.Console.ForegroundColor = ConsoleColor.Green;
					break;
				case Color.Yellow:
					System.Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				case Color.Cyan:
					System.Console.ForegroundColor = ConsoleColor.Cyan;
					break;
				default:
					System.Console.ForegroundColor = ConsoleColor.White;
					break;
			}

			System.Console.WriteLine(message);
			System.Console.ResetColor();
		}
	}
}
