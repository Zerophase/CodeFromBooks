#ifndef CARD_H
#define CARD_H

#include "Equipment.h"

class Card : public Equipment
{
public:
	Card(const char *name);
	virtual ~Card();

	virtual Watt Power();
	virtual Currency NetPrice();
	virtual Currency DiscountPrice();

	virtual void Accept(EquipmentVisitor&);
};
#endif // !CARD_H
