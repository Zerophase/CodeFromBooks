#ifndef EQUIPMENT_H
#define EQUIPMENT_H

#include "Watt.h"
#include "Currency.h"
#include "Iterator.h"

class Equipment
{
	public:
		virtual ~Equipment();

		const char *Name();

		virtual Watt Power();
		virtual Currency NetPrice();
		virtual Currency DiscountPrice();

		virtual void Add(Equipment *equipment);
		virtual void Remove(Equipment *equipment);
		virtual Iterator<Equipment*> *CreateIterator();
	protected:
		Equipment(const char *name);
	private:
		//Iterator<Equipment*> it;
		Watt watt;
		Currency currency;
		const char *name;
};
#endif // !EQUIPMENT_H
