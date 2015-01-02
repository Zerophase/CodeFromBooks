using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH5.LogAn
{
	public class LogAnalyzer2_IMulti
	{
		private ILogger _logger;
		private IWebService_CH5 _webService;

		public LogAnalyzer2_IMulti(ILogger logger, IWebService_CH5 webService)
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
					_logger.LogError(
						string.Format("Filename too short: {0}", filename));
				}
				catch (Exception e)
				{
					_webService.Write("Error From Logger: " + e);
				}
			}
		}
	}
}
