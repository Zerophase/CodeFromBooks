#include "HelpHandler.h"

HelpHandler::HelpHandler(HelpHandler *helpHandler, Topic topic)
{
	successor = helpHandler;
	theTopic = topic;
}

bool HelpHandler::HasHelp()
{
	return theTopic != NO_HELP_TOPIC;
}


void HelpHandler::SetHandler(HelpHandler *helpHandler, Topic topic)
{

}

void HelpHandler::HandleHelp()
{
	if (successor != 0)
	{
		successor->HandleHelp();
	}
}