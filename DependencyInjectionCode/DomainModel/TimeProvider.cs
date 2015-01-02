using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
	// This is great for supporting Unit tests.
	// NOTE Replace all calls to Time.DeltaTime in DYM with this pattern
	public abstract class TimeProvider
	{
		private static TimeProvider current;

		// NOTE AMbient Context
		// Initializes to a default that is always returned.
		static TimeProvider()
		{
			TimeProvider.current =
				new DefaultTimeProvider();
		}

		// Call Current and then Call UtcNow to take advantage of ambient Context pattern
		public static TimeProvider Current
		{
			get { return TimeProvider.current; }
			set
			{
				// Guarantees that the Ambient Context is never set to null
				if (value == null)
				{
					throw new ArgumentException("value");
				}
				TimeProvider.current = value;
			}
		}

		// Ensures the correct current value is distributed for all classes involved
		public abstract DateTime UtcNow { get; }

		public static void ResetToDefault()
		{
			TimeProvider.current = new DefaultTimeProvider();
		}
	}
}
