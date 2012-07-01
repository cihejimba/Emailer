//
// File: MassMailer.cs
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
	class MassMailer
	{
		private readonly string _password;

		private List<string> mailList = new List<string>();
		private readonly SmtpMailer mailer = new SmtpMailer();

		public MassMailer(string from, string subject, 
											string body, string host, 
											string password, int port = 587)
		{
			mailer.from = from;
			mailer.subject = subject;
			mailer.body = body;
			mailer.host = host;
			this._password = password;
			mailer.port = port;
		}

		public void Add( List<string> mailList )
		{
			this.mailList = mailList;
		}

		public void Add(string[] mailAddresses)
		{
			foreach (var address in mailAddresses)
			{
				mailList.Add(address);
			}
		}

		public void Add(string address)
		{
			mailList.Add(address);
		}

		public void Send()
		{
			foreach(var address in mailList) 
			{
				mailer.to = address;
				mailer.Send(_password);	
			}
		}
	}
}
