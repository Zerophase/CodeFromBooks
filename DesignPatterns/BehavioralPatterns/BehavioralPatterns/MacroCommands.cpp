#include "MacroCommand.h"

MacroCommand::MacroCommand()
{

}

MacroCommand::~MacroCommand()
{

}

void MacroCommand::Add(Command *command)
{
	cmds->push_back(command);
}

void MacroCommand::Remove(Command *command)
{
	cmds->remove(command);
}

void MacroCommand::Execute()
{
	list<Command*>::iterator i;

	for (i = cmds->begin(); i != cmds->end(); i++)
	{
		//Need to make list class so this works like the book.
		//Setting up a list iterator class comes later in the book.
		Command *c = cmds->front();
		c->Execute();
	}
}