#include "Dialog.h"

Dialog::Dialog(HelpHandler *h, Topic t)
	: Widget(0)
{
	SetHandler(h, t);
}

void Dialog::HandleHelp()
{
	if (HasHelp())
	{
		//Offer help on the dialog
	}
	else
		HelpHandler::HandleHelp();
}