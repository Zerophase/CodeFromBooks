#ifndef VARIABLEEXP_H
#define VARIABLEEXP_H

#include "BooleanExp.h"

class VariableExp : public BooleanExp
{
public:
	VariableExp(const char *);
	virtual ~VariableExp();
	
	virtual bool Evaluate(Context &);
	virtual BooleanExp *Replace(const char *, BooleanExp &);
	virtual BooleanExp *Copy() const;
private:
	char *name;
};
#endif // !VARIABLEEXP_H
