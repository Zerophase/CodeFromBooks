#ifndef ANDEXP_H
#define ANDEXP_H

#include "BooleanExp.h"

class AndExp : public BooleanExp
{
public:
	AndExp(BooleanExp *, BooleanExp *);
	virtual ~AndExp();

	virtual bool Evaluate(Context &);
	virtual BooleanExp *Replace(const char *, BooleanExp &);
	virtual BooleanExp *Copy() const;
private:
	BooleanExp *operandOne;
	BooleanExp *operandTwo;
};
#endif // !ANDEXP_H
