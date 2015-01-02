#include "Currency.h"

Currency::Currency()
{
	this->amount = 1;
}

Currency::Currency(int amount)
{
	this->amount = amount;
}

Currency operator+=(Currency &c1, Currency &c2)
{
	c1.amount += c2.amount;
	return c1;
}

std::ostream &operator<<(std::ostream &os, Currency &c)
{
	return os << c.amount;
}