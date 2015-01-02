#include "Chassis.h"
#include "EquipmentVisitor.h"
#include <list>

Chassis::Chassis(const char *name)
	: Equipment(name)
{
	_parts = new std::list<Equipment*>();
	_parts->push_back(new Bus("High Speed"));
}

Chassis::~Chassis()
{

}

Watt Chassis::Power()
{
	return Equipment::Power();
}

Currency Chassis::NetPrice()
{
	return Equipment::NetPrice();
}

Currency Chassis::DiscountPrice()
{
	return Equipment::DiscountPrice();
}

// A chassis contains all of the other parts
void Chassis::Accept(EquipmentVisitor &visitor)
{
	// how to implement for composite pattern
	std::list<Equipment*>::const_iterator it;

	for (it = _parts->begin(); it != _parts->end(); it++)
	{
		(*it)->Accept(visitor);
	}
	visitor.VisitChassis(this);
}