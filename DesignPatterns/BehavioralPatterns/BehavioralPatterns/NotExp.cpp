#include "NotExp.h"
#include "VariableExp.h"
#include "Context.h"

NotExp::NotExp(BooleanExp *name)
{
	this->name = name;
}

NotExp::~NotExp()
{

}

bool NotExp::Evaluate(Context &aContext)
{
	return !name->Evaluate(aContext);
}

BooleanExp *NotExp::Replace(const char *word, BooleanExp &exp)
{
	return new NotExp(name->Replace(word, exp));
}

BooleanExp *NotExp::Copy() const
{
	return new NotExp(name->Copy());
}