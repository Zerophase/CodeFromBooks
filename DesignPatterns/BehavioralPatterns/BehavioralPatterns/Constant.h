#ifndef CONSTANT_H
#define CONSTANT_H

#include "BooleanExp.h"

class Constant : public BooleanExp
{
public:
	Constant(bool);
	virtual ~Constant();

	virtual bool Evaluate(Context &);
	virtual BooleanExp *Replace(const char *name, BooleanExp &);
	virtual BooleanExp *Copy() const;
private:
	char *name;
};
#endif // !CONSTANT_H
