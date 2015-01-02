#ifndef PRICING_VISITOR_H
#define PRICING_VISITOR_H

#include "EquipmentVisitor.h"

class PricingVisitor : public EquipmentVisitor
{
public:
	PricingVisitor();

	Currency &GetTotalPrice();

	virtual void VisitFloppyDisk(FloppyDisk*);
	virtual void VisitCard(Card*);
	virtual void VisitBus(Bus*);
	virtual void VisitChassis(Chassis*);

private:
	Currency _total;
};
#endif // !PRICING_VISITOR_H
