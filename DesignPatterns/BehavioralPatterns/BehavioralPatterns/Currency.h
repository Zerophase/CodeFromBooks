#ifndef CURRENCY_H
#define CURRENCY_H

#include <ostream>

class Currency
{
public:
	Currency();
	Currency(int amount);

	friend Currency operator+=(Currency& c1, Currency& c2);
	friend std::ostream &operator<<(std::ostream &os, Currency &c);

private:
	int amount;
};
#endif // !CURRENCY_H
