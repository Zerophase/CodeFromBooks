#ifndef LISTTRAVERSER_H
#define LISTTRAVERSER_H

#include "List.h"

template<class Item>
class ListTraverser
{
public:
	ListTraverser(List <Item> *aList);
	bool Traverse();
protected:
	virtual bool ProcessItem(const Item&) = 0;
private:
	ListIterator<Item> _iterator;
};
#endif // !LISTTRAVERSER_H
