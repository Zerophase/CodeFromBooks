#ifndef ITERATOR_H
#define ITERATOR_H

template<class T>
class Iterator
{
	T Data;
	public:
		Iterator(T name);
		//Iterator();
		T First();
		T IsDone();
		T Next();
};
#endif // !ITERATOR_H
