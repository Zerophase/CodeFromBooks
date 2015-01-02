using System;
using System.ComponentModel;
using System.Reflection;

namespace PresentationLogic
{
	public class ProductEditorViewModel : IDataErrorInfo, INotifyPropertyChanged
	{
		private readonly int id;
		private string currency;
		private string name;
		private string price;
		private string title;

		public ProductEditorViewModel(int id)
		{
			Currency = string.Empty;
			this.id = id;
			Name = string.Empty;
			Price = string.Empty;
			Title = string.Empty;
		}

		public string Currency
		{
			get { return this.currency; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (this.currency != value)
				{
					var wasValid = this.IsValid;
					this.currency = value;
					this.OnPropertyChanged(new PropertyChangedEventArgs("Currency"));
					this.NotifyValid(wasValid);
				}
			}
		}

		public int Id
		{
			get { return this.id; }
		}

		public bool IsValid
		{
			get
			{
				return this.IsCurrencyValid
					&& this.IsNameValid
					&& this.IsPriceValid;
			}
		}

		public string Name
		{
			get { return this.name; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (this.name != value)
				{
					var wasValid = this.IsValid;
					this.name = value;
					this.OnPropertyChanged(new PropertyChangedEventArgs("Name"));
					this.NotifyValid(wasValid);
				}
			}
		}

		public string Price
		{
			get { return this.price; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (this.price != value)
				{
					var wasValid = this.IsValid;
					this.price = value;
					this.OnPropertyChanged(new PropertyChangedEventArgs("Price"));
					this.NotifyValid(wasValid);
				}
			}
		}

		public string Title
		{
			get { return this.title; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (this.title != value)
				{
					var wasValid = this.IsValid;
					this.title = value;
					this.OnPropertyChanged(new PropertyChangedEventArgs("Title"));
					this.NotifyValid(wasValid);
				}
			}
		}

		#region IDataErrorInfo Members

		public string Error
		{
			get
			{
				return this.IsValid ? string.Empty : "One or more values are invalid.";
			}
		}

		public string this[string columnName]
		{
			get
			{
				switch (columnName)
				{
					case "Currency":
						return this.IsCurrencyValid ? string.Empty : "Currency must be either DKK, USD or EUR";
					case "Name":
						return this.IsNameValid ? string.Empty : "Name must be at least one character long.";
					case "Price":
						return this.IsPriceValid ? string.Empty : "Price must be a number.";
					default:
						return string.Empty;
				}
			}
		}

		#endregion

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			var handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		private bool IsCurrencyValid
		{
			get
			{
				return Currency == "DKK" ||
				       Currency == "USD" ||
				       Currency == "EUR";
			}
		}

		private bool IsNameValid
		{
			get { return this.Name.Length > 0; }
		}

		private bool IsPriceValid
		{
			get
			{
				decimal p;
				return decimal.TryParse(this.price, out p);
			}
		}

		private void NotifyValid(bool wasValid)
		{
			if (this.IsValid != wasValid)
			{
				this.OnPropertyChanged(new PropertyChangedEventArgs("IsValid"));
			}
		}
	}
}