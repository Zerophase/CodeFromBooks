#ifndef BOOLEANEXP_H
#define BOOLEANEXP_H

#include <iostream>

class Context;

class BooleanExp
{
public:
	BooleanExp();
	virtual ~BooleanExp();

	virtual bool Evaluate(Context &context) = 0;
	virtual BooleanExp *Replace(const char *, BooleanExp &) = 0;
	virtual BooleanExp *Copy() const = 0;
};
#endif // !BOOLEANEXP_H
