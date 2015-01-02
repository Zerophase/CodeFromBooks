#include "Equipment.h"
#include "EquipmentVisitor.h"

Equipment::Equipment(const char *name)
{
	_name = name;
}

Equipment::~Equipment()
{

}

const char *Equipment::Name()
{
	return _name;
}

Watt Equipment::Power()
{
	Watt *w = new Watt();
	return *w;
}

Currency Equipment::NetPrice()
{
	Currency *c = new Currency();
	return *c;
}

Currency Equipment::DiscountPrice()
{
	Currency *c = new Currency();
	return *c;
}

void Equipment::Accept(EquipmentVisitor &visitor)
{
	
}