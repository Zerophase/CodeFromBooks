#include "FloppyDisk.h"
#include "EquipmentVisitor.h"

FloppyDisk::FloppyDisk(const char *name)
	: Equipment(name)
{

}

FloppyDisk::~FloppyDisk()
{

}

Watt FloppyDisk::Power()
{
	return Equipment::Power();
}

Currency FloppyDisk::NetPrice()
{
	return Equipment::NetPrice();
}

Currency FloppyDisk::DiscountPrice()
{
	return Equipment::DiscountPrice();
}

void FloppyDisk::Accept(EquipmentVisitor &visitor)
{
	visitor.VisitFloppyDisk(this);
}