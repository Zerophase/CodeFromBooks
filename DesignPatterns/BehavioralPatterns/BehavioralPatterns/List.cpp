#include "List.h"
#include "Iterator.h"
#include "ListIterator.h"

template <class Item>
List<Item>::List(long size)
{
	length = size;

	node = new Node;
	Node *temp = node;

	for (int i = 0; i < size; i++)
	{
		node->Index = i;
		if (temp->Index != node->Index)
			temp = node;
			

		node->Next = new Node;
		node = node->Next;

		node->Prev = temp;
	}
}

template <class Item>
List<Item>::List(List &listOfNodes)
{
	for (int i = 0; i < listOfNodes.length; i++)
	{
		//TODO edit once list methods are made.
		this->node = listOfNodes->node;
		
	}
}

template<class Item>
List<Item>::~List()
{

}

template<class Item>
List<Item> &List<Item>::operator=(const List &otherList)
{
	//TODO check to see if this works
	return this = otherList;
}

template<class Item>
long List<Item>::Count() const
{
	return this->length;
}

template<class Item>
Item &List<Item>::Get(long index) const
{
	Node *temp = this->node;
	while (temp->Index != index)
		temp = temp->Next
	return temp;
}

template<class Item>
Item &List<Item>::First() const
{
	//TODO check to make sure this returns the first node
	return node;
}

template<class Item>
Item &List<Item>::Last() const
{
	//TODO test if this works
	return node->Index = length - 1
}

template<class Item>
bool List<Item>::Includes(const Item &itemType) const
{
	//TODO implement generic search
	for (int i = 0; i < this->Count(); i++)
	{
		if (node == itemType)
			return true;
		else if (node->Index == this->Count())
			return false;
	}
}

template<class Item>
Iterator<Item> *List<Item>::CreateIterator() const
{
	return new ListIterator<Item>(this);
}