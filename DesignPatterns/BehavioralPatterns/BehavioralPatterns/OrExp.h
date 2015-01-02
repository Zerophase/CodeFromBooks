#ifndef OREXP_H
#define OREXP_H

#include "BooleanExp.h"

class OrExp : public BooleanExp
{
public:
	OrExp(BooleanExp *, BooleanExp *);
	virtual ~OrExp();

	virtual bool Evaluate(Context &);
	virtual BooleanExp *Replace(const char *, BooleanExp &);
	virtual BooleanExp *Copy() const;
private:
	BooleanExp *operandOne;
	BooleanExp *operandTwo;
};
#endif // !OREXP_H
