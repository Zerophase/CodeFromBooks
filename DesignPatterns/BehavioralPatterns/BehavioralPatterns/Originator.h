#ifndef ORIGINATOR_H
#define ORIGINATOR_H

#include "Memento.h"

class State;

class Originator
{
public:
	Memento *CreateMemento();
	void SetMemento(const Memento*);

private:
	State *_state;
};
#endif // !ORIGINATOR_H
