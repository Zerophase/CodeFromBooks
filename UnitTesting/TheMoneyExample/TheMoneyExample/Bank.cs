using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMoneyExample_TDD
{
	public class Bank
	{
		private Dictionary<Pair, int> rates = new Dictionary<Pair, int>();

		///<summary>
		/// add rate
		/// </summary>
		public void addRate(string from, string to, int rate)
		{
			rates.Add(new Pair(from, to), rate);
		}
		public Money reduce(Expression source, string to)
		{
			return source.reduce(to);
		}

		public int rate(string from, string to)
		{
			if (from.Equals(to))
				return 1;
			int value;
			rates.TryGetValue(new Pair(from, to), out value);
			return value;
		}

		private class Pair
		{
			private string from;
			private string to;

			public Pair(string from, string to)
			{
				this.from = from;
				this.to = to;
			}

			public override bool Equals(object obj)
			{
				Pair pair = (Pair)obj;
				return from.Equals(pair.from) && to.Equals(pair.to);
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}
	}
}
