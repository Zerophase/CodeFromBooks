#ifndef SIMPLECOMMAND_H
#define SIMPLECOMMAND_H

#include "Command.h"

template <class Receiver>
class SimpleCommand : public Command
{
public:
	typedef void(Receiver::*Action)();
	
	SimpleCommand(Receiver *r, Action a) :
		_receiver(r), _action(a) { }

	virtual void Execute() { (_receiver->*_action)(); }
private:
	Action _action;
	Receiver *_receiver;
};
#endif // !SIMPLECOMMAND_H
