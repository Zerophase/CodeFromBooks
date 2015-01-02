#ifndef EQUIPMENT_VISITOR_H
#define EQUIPMENT_VISITOR_H

#include "FloppyDisk.h"
#include "Card.h"
#include "Chassis.h"
#include "Bus.h"

class EquipmentVisitor
{
public:
	virtual ~EquipmentVisitor();

	virtual void VisitFloppyDisk(FloppyDisk*);
	virtual void VisitCard(Card*);
	virtual void VisitChassis(Chassis*);
	virtual void VisitBus(Bus*);

	// etc for other concrete classes

protected:
	EquipmentVisitor();
};
#endif // !EQUIPMENT_VISITOR_H
