#ifndef LIST_H
#define LIST_H

#include "MyClass.h"
#include "Iterator.h"
#include "AbstractList.h"
#include "ListIterator.h"

const int DEFAULT_LIST_CAPACITY = 2;

//TODO if broken use the built in list class.
//TODO see if need to add a template to this
struct Node
{
public:
	//Node *Current;
	Node *Next;
	Node *Prev;
	long Index;
};




template <class Item>
class List : AbstractList<Item>
{
public:
	List(long size = DEFAULT_LIST_CAPACITY);
	List(List&);
	~List();
	List &operator=(const List&);

	long Count() const;
	Item &Get(long index) const;
	Item &First() const;
	Item &Last() const;
	bool Includes(const Item&) const;

	virtual Iterator<Item> *CreateIterator() const;
	
	/*void Append(const Item&);
	void Prepend(const Item&);

	void Remove(const Item&);
	void RemoveLast();
	void RemoveFirst();
	void RemoveAll();
	
	Item &Top() const;
	void Push(const Item&);
	Item &Pop();*/
private:
	long length;
	Node *node;
	Node *nextNode;
	Node *prevNode;
};


class Item
{
public:
	Item()
	{

	}
};



#endif // !LIST_H
