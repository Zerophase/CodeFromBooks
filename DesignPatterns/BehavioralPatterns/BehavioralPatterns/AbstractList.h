#ifndef ABSTRACTLIST_H
#define ABSTRACTLIST_H

#include "Iterator.h"

template<class Item>
class AbstractList
{
public:
	virtual Iterator<Item> *CreateIterator() const = 0;
};
#endif // !ABSTRACTLIST_H
