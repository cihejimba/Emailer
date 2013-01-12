//
// File: Program.cs
//
// Author: Corey Prophitt <prophitt.corey@gmail.com>
//
// Copyright: See the readme.
//

#region Using Statements

using System;
using System.Linq;
using System.Xml;

#endregion

namespace Emailer
{
    class Program
    {

        //
        // Note: Next time just use an app.config :) 
        //
        static void Main(string[] args)
        {
            // Parse the config file 
            XmlDocument config = new XmlDocument();
            try
            {
	            config.Load("../../config.xml");
            }
            catch(Exception ex) 
            {
	            Console.WriteLine("ERROR: Exception while reading configuration file.", Color.Red);
	            Console.WriteLine(ex.Message, Color.Red);
            }

            var root = config.FirstChild;

            var username = root["username"].InnerXml;
            var password = root["password"].InnerXml;
            var subject = root["subject"].InnerXml;
            var body = root["body"].InnerXml;
            var host = root["host"].InnerXml;
            var recipients = root["recipients"].InnerXml.Trim();

            // Parse the recipients file
            Console.WriteLine("INFO: Reading " + recipients, Color.Yellow);

            var emails = new CsvReader(recipients).Read();
            if (emails != null)
            {
	            Console.WriteLine(string.Format("INFO: Attempting to send {0} emails.", emails.Count), Color.Cyan);

	            // Email all recipients a copy of the message
	            var massMailer = new MassMailer(username, subject, body, host, password);
	            massMailer.Add(emails);
	            massMailer.Send();
            }
            else
            {
	            Console.WriteLine("ERROR: No emails extracted.", Color.Red);
            }

            Console.WriteLine("Finished! Press enter to quit.", Color.Cyan);
            System.Console.ReadLine();
        } // end Main

    } // end class Program
} // end namespace