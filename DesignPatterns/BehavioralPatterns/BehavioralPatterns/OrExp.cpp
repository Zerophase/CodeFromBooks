#include "OrExp.h"

OrExp::OrExp(BooleanExp *opOne, BooleanExp *opTwo)
{
	operandOne = opOne;
	operandTwo = opTwo;
}

OrExp::~OrExp()
{

}

bool OrExp::Evaluate(Context &aContext)
{
	return operandOne->Evaluate(aContext) ||
		operandTwo->Evaluate(aContext);
}

BooleanExp *OrExp::Replace(const char *name, BooleanExp &exp)
{
	return new OrExp(operandOne->Replace(name, exp),
		operandTwo->Replace(name, exp));
}

BooleanExp *OrExp::Copy() const
{
	return new OrExp(operandOne->Copy(),
		operandTwo->Copy());
}