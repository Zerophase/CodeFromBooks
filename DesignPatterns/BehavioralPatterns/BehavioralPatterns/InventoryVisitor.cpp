#include "InventoryVisitor.h"

InventoryVisitor::InventoryVisitor()
{

}

Inventory &InventoryVisitor::GetInventory()
{
	return _inventory;
}

void InventoryVisitor::VisitFlopyyDisk(FloppyDisk *f)
{
	_inventory.Accumulate(f);
}

void InventoryVisitor::VisitChassis(Chassis *c)
{
	_inventory.Accumulate(c);
}

void InventoryVisitor::VisitBus(Bus *b)
{
	_inventory.Accumulate(b);
}

void InventoryVisitor::VisitCard(Card *c)
{
	_inventory.Accumulate(c);
}