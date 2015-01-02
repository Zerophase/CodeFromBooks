#ifndef MACROCOMMAND_H
#define MACROCOMMAND_H

#include "Command.h"
#include <list>

using namespace std;

class MacroCommand : public Command
{
public:
	MacroCommand();
	virtual ~MacroCommand();

	virtual void Add(Command *command);
	virtual void Remove(Command *command);

	virtual void Execute();
private:	
	list<Command*> *cmds;
};
#endif // !MACROCOMMAND_H
