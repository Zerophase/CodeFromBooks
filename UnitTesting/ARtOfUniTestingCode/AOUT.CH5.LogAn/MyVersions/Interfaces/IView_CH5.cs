using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH5.LogAn
{
	public interface IView_CH5
	{
		// Takes a method that takes a string
		event Action<string> ErrorOccured;
		event Action Loaded;
		void Render(string text);
	}
}
