#ifndef INVENTORY_VISITOR_H
#define INVENTORY_VISITOR_H

#include "EquipmentVisitor.h"
#include "Inventory.h"
#include "FloppyDisk.h"
#include "Bus.h"
#include "Chassis.h"
#include "Card.h"

class InventoryVisitor : public EquipmentVisitor
{
public:
	InventoryVisitor();

	Inventory &GetInventory();

	virtual void VisitFlopyyDisk(FloppyDisk*);
	virtual void VisitChassis(Chassis*);
	virtual void VisitBus(Bus*);
	virtual void VisitCard(Card*);

private:
	Inventory _inventory;
};
#endif // !INVENTORY_VISITOR_H
