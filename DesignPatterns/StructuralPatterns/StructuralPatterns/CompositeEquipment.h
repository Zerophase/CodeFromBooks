#ifndef COMPOSITEEQUIPMENT_H
#define COMPOSITEEQUIPMENT_H

#include "Equipment.h"

class CompositeEquipment : public Equipment
{
	public:
		virtual ~CompositeEquipment();

		virtual Watt Power();
		virtual Currency NetPrice();
		virtual Currency DiscountPrice();

		virtual void Add(Equipment *equipment);
		virtual void Remove(Equipment *equipment);
		virtual Iterator<Equipment*> *CreateIterator();

	protected:
		CompositeEquipment(const char *name);
	private:
		//List<Equipment*> equipments;
};
#endif // !COMPOSITEEQUIPMENT_H
