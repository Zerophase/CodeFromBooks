#ifndef SKIPLIST_H
#define SKIPLIST_H

#include "Iterator.h"
#include "List.h"

template<class Item>
class SkipList : public Iterator<Item>
{
public:
	SkipList();
};
#endif