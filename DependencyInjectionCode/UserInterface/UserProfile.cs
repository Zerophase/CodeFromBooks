using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace UserInterface
{
	public class UserProfile : ProfileBase
	{
		#region IUserProfile Members

		public virtual string Currency
		{
			get { return (string)this["Currency"]; }
			set { this["Currency"] = value; }
		}

		#endregion
	}
}