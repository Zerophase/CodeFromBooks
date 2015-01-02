#ifndef LISTITERATOR_H
#define LISTITERATOR_H

#include "Iterator.h"
template<class Item>
class List;

template <class Item>
class ListIterator : public Iterator<Item>
{
public:
	ListIterator(const List<Item>* aList);
	virtual void First();
	virtual void Next();
	virtual bool IsDone() const;
	virtual Item CurrentItem() const;

private:
	const List<Item> *_list;
	long _current;
};
#endif // !LISTITERATOR_H
