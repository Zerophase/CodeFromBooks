using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH5.LogAn
{
	public interface IWebService_ErrorInfo
	{
		void Write(string message);
		void Write(ErrorInfo message);
	}
}
