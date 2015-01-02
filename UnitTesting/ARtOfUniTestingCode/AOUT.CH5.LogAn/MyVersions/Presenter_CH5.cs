using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH5.LogAn
{
	public class Presenter_CH5
	{
		private readonly IView_CH5 _view;
		private readonly ILogger _logger;

		public Presenter_CH5(IView_CH5 view)
		{
			_view = view;
			this._view.Loaded += OnLoaded;
		}

		public Presenter_CH5(IView_CH5 view, ILogger logger)
		{
			_view = view;
			this._view.Loaded += OnLoaded;
			this._view.ErrorOccured += OnError;
			_logger = logger;
		}

		private void OnLoaded()
		{
			_view.Render("Hello World");
		}

		private void OnError(string text)
		{
			 _logger.LogError(text);
		}
	}
}
