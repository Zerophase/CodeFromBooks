using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH4.LogAn
{
	public class LogAnalyzer2_FromBook_2dExample
	{
		public LogAnalyzer2_FromBook_2dExample(IWebService service, IEmailService_WithProperties email)
		{
			Email = email;
			Service = service;
		}

		public IWebService Service
		{
			get;
			set;
		}

		public IEmailService_WithProperties Email
		{
			get;
			set;
		}

		private EmailInfo email;

		public void Analyze(string fileName)
		{
			if (fileName.Length < 8)
			{
				try
				{
					Service.LogError("Filename too short:" + fileName);
				}
				catch (Exception e)
				{
					email = new EmailInfo
					{
						Body = e.Message,
						To = "someone@somewhere.com",
						Subject = "can't log"
					};
					Email.SendEmail(email);
				}
			}
		}
	}
}
