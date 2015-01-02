#ifndef BUS_H
#define BUS_H

#include "Equipment.h"

class Bus : public Equipment
{
public:
	Bus(const char *name);
	virtual ~Bus();

	virtual Watt Power();
	virtual Currency NetPrice();
	virtual Currency DiscountPrice();

	virtual void Accept(EquipmentVisitor&);
};
#endif // !BUS_H
