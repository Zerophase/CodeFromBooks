#include "Inventory.h"

Inventory::Inventory()
{

}

Inventory::~Inventory()
{

}

void Inventory::Accumulate(Equipment *e)
{
	_contents.push_back(e);
}