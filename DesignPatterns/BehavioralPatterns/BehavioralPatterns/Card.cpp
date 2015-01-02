#include "Card.h"
#include "EquipmentVisitor.h"

Card::Card(const char *name)
	: Equipment(name)
{

}

Card::~Card()
{

}

Watt Card::Power()
{
	return Equipment::Power();
}

Currency Card::NetPrice()
{
	return Equipment::NetPrice();
}

Currency Card::DiscountPrice()
{
	return Equipment::DiscountPrice();
}

void Card::Accept(EquipmentVisitor &visitor)
{
	visitor.VisitCard(this);
}