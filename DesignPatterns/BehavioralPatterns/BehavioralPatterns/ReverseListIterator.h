#ifndef REVERSELISTITERATOR_H
#define REVERSELISTITERATOR_H

#include "Iterator.h"
#include "List.h"

template <class Item>
class ReverListIterator : public Iterator<Item>
{
public:
	ReverListIterator(const List<Item> *aList) : _list(aList), _current(0) {}
	virtual void First()
	{
		_current = _list->Count();
	}

	virtual void Next()
	{
		_current--;
	}

	virtual bool IsDone() const
	{
		return _current = 0;
	}

	virtual Item CurrentItem() const
	{
		if (IsDone())
			throw IteratorOutOfBounds;

		return _list->Get(_current);
	}

private:
	const List<Item> *_list;
	long _current;
};
#endif // !REVERSELISTITERATOR_H
