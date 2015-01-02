#include "VariableExp.h"
#include "Context.h"

VariableExp::VariableExp(const char *name)
{
	this->name = _strdup(name);
}

VariableExp::~VariableExp()
{

}

bool VariableExp::Evaluate(Context &aContext)
{
	return aContext.LookUp(name);
}

BooleanExp *VariableExp::Replace(const char *name, BooleanExp &exp)
{
	if (strcmp(name, this->name) == 0)
	{
		return exp.Copy();
	}
	else
		return new VariableExp(name);
}

BooleanExp *VariableExp::Copy() const
{
	return new VariableExp(name);
}