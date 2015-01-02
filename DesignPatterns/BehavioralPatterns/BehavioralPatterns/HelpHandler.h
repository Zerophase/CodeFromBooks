#ifndef HELPHANDLER_H
#define HELPHANDLER_H

typedef int Topic;
const Topic NO_HELP_TOPIC = -1;

class HelpHandler
{
public:
	HelpHandler(HelpHandler *helpHandler = 0, Topic = NO_HELP_TOPIC);
	virtual bool HasHelp();
	virtual void SetHandler(HelpHandler *helpHandler, Topic topic);
	virtual void HandleHelp();
private:
	HelpHandler *successor;
	Topic theTopic;
};
#endif // !HELPHANDLER_H
