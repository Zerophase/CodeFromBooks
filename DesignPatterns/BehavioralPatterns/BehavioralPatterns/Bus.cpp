#include "Bus.h"
#include "EquipmentVisitor.h"

Bus::Bus(const char *name)
	: Equipment(name)
{

}

Bus::~Bus()
{

}

Watt Bus::Power()
{
	return Equipment::Power();
}

Currency Bus::NetPrice()
{
	return Equipment::NetPrice();
}

Currency Bus::DiscountPrice()
{
	return Equipment::DiscountPrice();
}

void Bus::Accept(EquipmentVisitor &visitor)
{
	visitor.VisitBus(this);
}