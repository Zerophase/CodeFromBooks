using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH5.LogAn
{
	public class LogAnalyzer3
	{
		private ILogger _logger;
		private IWebService_ErrorInfo _webService;

		public LogAnalyzer3(ILogger logger, IWebService_ErrorInfo webService)
		{
			_logger = logger;
			_webService = webService;
		}

		public int MinNameLength { get; set; }

		public void Analyze(string filename)
		{
			if (filename.Length < MinNameLength)
			{
				try
				{
					_logger.LogError(string.Format("Filename too short: {0}", filename));
				}
				catch (Exception e)
				{
					_webService.Write(new ErrorInfo(1000, e.Message));
				}
			}
		}
	}
}
