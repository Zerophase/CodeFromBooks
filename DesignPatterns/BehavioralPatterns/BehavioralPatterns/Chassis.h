#ifndef CHASSIS_H
#define CHASSIS_H

#include "Equipment.h"
#include <list>

class Chassis : public Equipment
{
public:
	Chassis(const char *name);
	virtual ~Chassis();

	virtual Watt Power();
	virtual Currency NetPrice();
	virtual Currency DiscountPrice();

	virtual void Accept(EquipmentVisitor&);

private:
	std::list<Equipment*> *_parts;
};
#endif // !CHASSIS_H
