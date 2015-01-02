using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TheMoneyExample_TDD;

namespace TheMoneyExample_TDD_Tests
{
	[TestFixture]
    public class MoneyTests
    {
		[Test]
		public void TestDollarMultiplication()
		{
			Money five = Money.dollar(5);
			Assert.AreEqual(Money.dollar(10), five.times(2));
			Assert.AreEqual(Money.dollar(15), five.times(3));
		}

		[Test]
		public void TestPlusReturnsSum()
		{
			Money five = Money.dollar(5);
			Expression result = five.plus(five);
			Sum sum = (Sum)result;
			Assert.AreEqual(five, sum.augend);
			Assert.AreEqual(five, sum.addend);
		}

		[Test]
		public void TestReduceSum()
		{
			Expression sum = new Sum(Money.dollar(3), Money.dollar(4));
			Bank bank = new Bank();
			Money result = bank.reduce(sum, "USD");
			Assert.AreEqual(Money.dollar(7), result);
		}

		[Test]
		public void TestReduceMoney()
		{
			Bank bank = new Bank();
			Money result = bank.reduce(Money.dollar(1), "USD");
			Assert.AreEqual(Money.dollar(1), result);
		}

		[Test]
		public void TestReduceMoneyDifferentCurrency()
		{
			Bank bank = new Bank();
			bank.addRate("CHF", "USD", 2);
			Money result = bank.reduce(Money.franc(2), "USD");
			Assert.AreEqual(Money.dollar(1), result);
		}

		[Test]
		public void TestMixedAddition()
		{
			Expression fiveBucks = Money.dollar(5);
			Expression tenFrancs = Money.franc(10);
			Bank bank = new Bank();
			bank.addRate("CHF", "USD", 2);
			Money result = bank.reduce(fiveBucks.plus(tenFrancs), "USD");
			Assert.AreEqual(Money.dollar(10), result);
		}

		[Test]
		public void TestSumPlusMoney()
		{
			Expression fiveBucks = Money.dollar(5);
			Expression tenFrancs = Money.franc(10);
			Bank bank = new Bank();
			bank.addRate("CHF", "USD", 2);
			Expression sum = new Sum(fiveBucks, tenFrancs).plus(fiveBucks);
			Money result = bank.reduce(sum, "USD");
			Assert.AreEqual(Money.dollar(15), result);
		}

		[Test]
		public void TestSumTimes()
		{
			Expression fiveBucks = Money.dollar(5);
			Expression tenFrancs = Money.franc(10);
			Bank bank = new Bank();
			bank.addRate("CHF", "USD", 2);
			Expression sum = new Sum(fiveBucks, tenFrancs).times(2);
			Money result = bank.reduce(sum, "USD");
			Assert.AreEqual(Money.dollar(20), result);
		}

		[Test]
		public void TestSimpleAddition()
		{
			Money five = Money.dollar(5);
			Expression sum = five.plus(five);
			Bank bank = new Bank();
			Money reduced = bank.reduce(sum, "USD");
			Assert.AreEqual(Money.dollar(10), reduced);
		}

		[Test]
		public void TestCurrency()
		{
			Assert.AreEqual("USD", Money.dollar(1).Currency());
			Assert.AreEqual("CHF", Money.franc(1).Currency());
		}

		[Test]
		public void TestEquality()
		{
			Assert.IsTrue(Money.dollar(5).Equals(Money.dollar(5)));
			Assert.IsFalse(Money.dollar(5).Equals(Money.dollar(6)));
			Assert.IsFalse(Money.franc(5).Equals(Money.dollar(5)));
		}

		[Test]
		public void TestIdentifyRate()
		{
			Assert.AreEqual(1, new Bank().rate("USD", "USD"));
		}

		[Test]
		public void TestArrayEquals()
		{
			Assert.AreEqual(new object[] { "abc" }, new object[] { "abc" });
		}
    }
}
