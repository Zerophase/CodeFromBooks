#include "Constant.h"
#include "Context.h"

Constant::Constant(bool state)
{
	if (state == true)
	{
		name = "true";
	}
	else
		name = "false";
}

Constant::~Constant()
{

}

bool Constant::Evaluate(Context &aContext)
{
	return aContext.LookUp(name);
}

BooleanExp *Constant::Replace(const char *name, BooleanExp &exp)
{
	if (strcmp(name, this->name) == 0)
	{
		return exp.Copy();
	}
	else
	{
		if (name == "true")
			return new Constant(true);
		else
			return new Constant(false);
	}
}

BooleanExp *Constant::Copy() const
{
	if (name == "true")
		return new Constant(true);
	else
		return new Constant(false);
}