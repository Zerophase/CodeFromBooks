using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH5.LogAn
{
	public class LogAnalyzer_ILogger
	{
		private ILogger logger;
		public LogAnalyzer_ILogger(ILogger log)
		{
			logger = log;
		}

		public int MinNameLength
		{
			get;
			set;
		}

		public virtual void Analyze(string input)
		{
			logger.LogError("Filename too short: " + input);
		}
	}
}
