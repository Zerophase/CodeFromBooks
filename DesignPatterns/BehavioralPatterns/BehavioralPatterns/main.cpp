
#include "Application.h"
#include "Button.h"
#include "Dialog.h"
#include "HelpHandler.h"
#include "Widget.h"

#include "SimpleCommand.h"
#include "MyClass.h"

#include "AndExp.h"
#include "OrExp.h"
#include "NotExp.h"
#include "Constant.h"
#include "VariableExp.h"
#include "Context.h"

#include "List.h"
#include "List.cpp"

// Observer Pattern
#include "ClockTimer.h"
#include "AnalogClock.h"
#include "DigitalClock.h"

// Strategy Pattern
#include "Composition.h"
#include "TeXCompositor.h"
#include "ArrayCompositor.h"
#include "SimpleCompositor.h"

// Template Method
#include "View.h"
#include "MyView.h"

// Visitor
#include "Equipment.h"
#include "EquipmentVisitor.h"
#include "InventoryVisitor.h"
#include "Chassis.h"
#include "PricingVisitor.h"

int main()
{
	//Chain of responsibility
	/*const Topic PRINT_TOPIC = 1;
	const Topic PAPER_ORIENTATION_TOPIC = 2;
	const Topic APPLICATION_TOPIC = 3;

	Application *application = new Application(APPLICATION_TOPIC);
	Dialog *dialog = new Dialog(application, PRINT_TOPIC);
	Button *button = new Button(dialog, PAPER_ORIENTATION_TOPIC);*/

	//Starts the search for what happens with the chain of responsibility
	/*button->HandleHelp();*/

	//Command
	//for simple commands
	/*MyClass *receiver = new MyClass;
	Command *aCommand =
		new SimpleCommand<MyClass>(receiver, &MyClass::Action);

	aCommand->Execute();*/

	//Interpreter
	/*BooleanExp *expression;
	Context context;

	VariableExp *x = new VariableExp("X");
	VariableExp *y = new VariableExp("Y");

	expression = new OrExp(new AndExp(new Constant(true), x),
		new AndExp(y, new NotExp(x)));

	context.Assign(x, false);
	context.Assign(y, true);

	bool result = expression->Evaluate(context);

	VariableExp *z = new VariableExp("Z");
	NotExp notZ(z);

	BooleanExp *replacement = expression->Replace("Y", notZ);

	context.Assign(z, true);

	result = replacement->Evaluate(context);*/

	/*long number = 3;
	
	List<Item> *theList = new List<Item>(number);*/

	// Observer pattern
	//ClockTimer *timer = new ClockTimer; // () isn't needed when calling default constructor
	//AnalogClock *analogClock = new AnalogClock(timer);
	//DigitalClock *digitalClock = new DigitalClock(timer);

	// Strategy Pattern
	/*Composition *quick = new Composition(new SimpleCompositor());
	Composition *slick = new Composition(new TeXCompositor());
	Composition *iconic = new Composition(new ArrayCompositor(100));*/

	// Template Method
	/*MyView *myView = new MyView();

	myView->Display();*/

	// Visitor Pattern

	Equipment *component = new Chassis("Cat");
	InventoryVisitor visitor;
	component->Accept(visitor);

	cout << "Inventory " << component->Name();
		//<< visitor.GetInventory(); // Implenent override allowing inventory to print
	cout << std::endl;

	PricingVisitor pVisitor;
	component->Accept(pVisitor);
	
	cout << "Price " << pVisitor.GetTotalPrice();

	return 0;
}