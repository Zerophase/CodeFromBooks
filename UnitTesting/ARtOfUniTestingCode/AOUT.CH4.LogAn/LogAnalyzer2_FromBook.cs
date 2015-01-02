using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH4.LogAn
{
	public class LogAnalyzer2_FromBook
	{
		public LogAnalyzer2_FromBook(IWebService service, IEmailService email)
		{
			Email = email;
			Service = service;
		}

		public IWebService Service
		{
			get;
			set;
		}

		public IEmailService Email
		{
			get;
			set;
		}


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
					Email.SendEmail("someone@somewhere.com", "can't log", e.Message);
				}
			}
		}
	}
}
