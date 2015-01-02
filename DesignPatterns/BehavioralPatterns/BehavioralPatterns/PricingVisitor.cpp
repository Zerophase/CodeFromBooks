#include "PricingVisitor.h"

PricingVisitor::PricingVisitor()
{

}

Currency &PricingVisitor::GetTotalPrice()
{
	return _total;
}

void PricingVisitor::VisitFloppyDisk(FloppyDisk *f)
{
	// check to see if works
	_total += f->NetPrice();
}

void PricingVisitor::VisitChassis(Chassis *c)
{
	_total += c->DiscountPrice();
}

void PricingVisitor::VisitBus(Bus *b)
{
	_total += b->NetPrice();
}

void PricingVisitor::VisitCard(Card *c)
{
	_total += c->NetPrice();
}