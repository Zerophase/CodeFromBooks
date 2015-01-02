using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssortedCodeSnippets.ConstructorInjection.OverInjection;

namespace Ploeh.Samples.AssortedCodeSnippets.ConstructorInjection.OverInjection
{
    public class MyClass
    {
		// NOTE SOlve having too many classes injected by combining them
		// into facades for instance combine ICoffeMaker and IKitchenSink

        public MyClass(IUnitOfWorkFactory uowFactory,
            CurrencyProvider currencyProvider,
            IFooPolicy fooPolicy,
            IBarService barService,
            ICoffeeMaker coffeeMaker,
            IKitchenSink kitchenSink)
        {
        }

		// Much cleaner with the Facade 
		// In real world would be further broken into
		// facades to cut down on Constructor parameter size
	    public MyClass(IUnitOfWorkFactory uowFactory,
		    CurrencyProvider currencyProvider,
		    IFooPolicy fooPolicy,
		    IBarService barService,
		    KitchenFacade kitchenFacade)
	    {
		    
	    }
    }
}
