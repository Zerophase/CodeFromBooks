#ifndef INVENTORY_H
#define INVENTORY_H

#include "Equipment.h"
#include <list>
#include <ostream>

class Inventory
{
public:
	Inventory();
	~Inventory();

	void Accumulate(Equipment*);

	std::list<Equipment*> _contents;
};
#endif // !INVENTORY_H
