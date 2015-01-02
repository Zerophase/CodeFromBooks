#include "Context.h"
#include "VariableExp.h"

bool Context::LookUp(const char *lookFor) const
{
	return true;
	//replace with search and return true if a member matches
}

void Context::Assign(VariableExp *variableExp, bool check)
{
	variableExps.push_back(make_pair(variableExp, check));
}