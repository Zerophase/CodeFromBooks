using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.Samples.AssortedCodeSnippets.ConstructorInjection.OverInjection;

namespace AssortedCodeSnippets.ConstructorInjection.OverInjection
{
	// NOTE Facade for breaking overinjection
	// class takes instances of classes related to it or
	// creates those class instances from within
	// then it supplies their methods to consumers.
	public class KitchenFacade
	{
		private readonly IKitchenSink kitchenSink;
		private readonly ICoffeeMaker coffeeMaker;
		public KitchenFacade(IKitchenSink kitchenSink, ICoffeeMaker coffeeMaker)
		{
			this.kitchenSink = kitchenSink;
			this.coffeeMaker = coffeeMaker;
		}

		// Calls methods that perform the actions from the classes
		// contained in the facade
		// in a realworld scenario each method might
		// use multiple classes the facade contains
		public string TurnOnSink()
		{
			return kitchenSink.TurnOnKitchenSink();
		}

		public string MakeCoffee()
		{
			return coffeeMaker.MakeCoffee();
		}
	}
}
