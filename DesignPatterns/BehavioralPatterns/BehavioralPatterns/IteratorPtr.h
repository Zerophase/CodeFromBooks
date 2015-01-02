#ifndef IteratorPtr_H
#define IteratorPtr_H

#include "Iterator.h"

template<class Item>
class IteratorPtr
{
public:
	IteratorPtr(Iterator<Item> *i) : _i(i) {}
	~IteratorPtr() { delete _i; }

	Iterator<Item> *operator->() { return _i; }
	Iterator<Item> &operator*() { return *_i; }

private:
	//disallow copy and assignment to avoid
	//muliple deletions of _i:
	IteratorPtr(const IteratorPtr&);
	IteratorPtr &operator=(const IteratorPtr&);
private:
	Iterator<Item> *_i;
};
#endif // !IteratorPtr_H
