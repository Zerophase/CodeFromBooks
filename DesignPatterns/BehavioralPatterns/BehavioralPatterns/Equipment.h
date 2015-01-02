#ifndef EQUIPMENT_H
#define EQUIPMENT_H

#include "Watt.h"
#include "Currency.h"

class EquipmentVisitor;

class Equipment
{
public:
	virtual ~Equipment();

	const char *Name();

	virtual Watt Power();
	virtual Currency NetPrice();
	virtual Currency DiscountPrice();

	virtual void Accept(EquipmentVisitor&);

protected:
	Equipment(const char*);

private:
	const char *_name;
};
#endif // !EQUIPMENT_H
