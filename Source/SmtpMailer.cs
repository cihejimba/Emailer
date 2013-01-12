//
// File: SmtpMailer.cs
//
// Author: Corey Prophitt <prophitt.corey@gmail.com>
//
// Copyright: See the readme.
//

#region Using Statements

using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;

#endregion

namespace Emailer
{
    class SmtpMailer
    {

        #region Properties

        public string host { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public int port { get; set; }

        #endregion

        #region Creation & Destruction

        public SmtpMailer( int port = 587 )
        {
	        this.port = port;
        }

        public SmtpMailer( string host, int port = 587 )
        {
	        this.host = host;
	        this.port = port;
        }

        public SmtpMailer( string from, string to, string subject, string body, int port = 587 )
        {
	        this.from = from;
	        this.to = to;
	        this.subject = subject;
	        this.body = body;
	        this.port = port;
        }

        public SmtpMailer( string host, string from, string to, string subject, string body, int port = 587 )
        {
	        this.host = host;
	        this.from = from;
	        this.to = to;
	        this.subject = subject;
	        this.body = body;
	        this.port = port;
        }

        #endregion

        #region Methods

        public void Send( string password, uint delay = 0 )
        {
	        var email = new MailMessage(from, to, subject, body);

	        var smtp = new SmtpClient(host, port);
	        smtp.Credentials = new NetworkCredential(from, password);
	        smtp.EnableSsl = true;

	        try
	        {
		        if (delay > 0)
		        {
			        Thread.Sleep(new TimeSpan(delay));
		        }
		        smtp.Send(email);
		        //smtp.SendAsync(email, null); 
	        }
	        catch (Exception ex)
	        {
		        Console.WriteLine("Error: an exception was caught!", Color.Red);
		        Console.WriteLine(ex.Message, Color.Red);
	        }

        }

        #endregion

    } // end class SmtpMailer
} // end namespace