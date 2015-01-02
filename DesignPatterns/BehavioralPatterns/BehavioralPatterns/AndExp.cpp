#include "AndExp.h"

AndExp::AndExp(BooleanExp *opOne, BooleanExp *opTwo)
{
	operandOne = opOne;
	operandTwo = opTwo;
}

AndExp::~AndExp()
{

}

bool AndExp::Evaluate(Context &aContext)
{
	return operandOne->Evaluate(aContext) &&
		operandTwo->Evaluate(aContext);
}

BooleanExp *AndExp::Replace(const char *name, BooleanExp &exp)
{
	return new AndExp(operandOne->Replace(name, exp),
		operandTwo->Replace(name, exp));
}

BooleanExp *AndExp::Copy() const
{
	return new AndExp(operandOne->Copy(),
		operandTwo->Copy());
}