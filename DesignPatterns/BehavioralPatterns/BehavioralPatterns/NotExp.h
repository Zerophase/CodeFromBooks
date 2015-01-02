#ifndef NOTEXP_H
#define NOTEXP_H

#include "BooleanExp.h"

class NotExp : public BooleanExp
{
public:
	NotExp(BooleanExp *);
	virtual ~NotExp();

	virtual bool Evaluate(Context &);
	virtual BooleanExp *Replace(const char *, BooleanExp &);
	virtual BooleanExp *Copy() const;
private:
	BooleanExp *name;
};
#endif // !NOTEXP_H
