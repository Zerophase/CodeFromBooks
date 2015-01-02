#ifndef DIALOG_H
#define DIALOG_H

#include "Widget.h"

class Dialog : public Widget
{
public:
	Dialog(HelpHandler *h, Topic t = NO_HELP_TOPIC);
	virtual void HandleHelp();

	//Widget operations dialog overrides
	//...
};
#endif // !DIALOG_H
