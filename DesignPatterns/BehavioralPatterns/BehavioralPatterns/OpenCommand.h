#ifndef OPENCOMMAND_H
#define OPENCOMMAND_H

#include "Command.h"

class Application;

class OpenCommand : public Command
{
public:
	OpenCommand(Application *application);

	virtual void Execute();
protected:
	virtual const char *AskUser();
private:
	Application *_application;
	char *_response;
};
#endif // !OPENCOMMAND_H
