using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOUT.CH4.LogAn;

namespace LogAn.UnitTests
{
	public class FakeEmailService_WithProperties : IEmailService_WithProperties
	{
		public EmailInfo email;
		public void SendEmail(EmailInfo emailInfo)
		{
			email = emailInfo;
		}
	}
}
