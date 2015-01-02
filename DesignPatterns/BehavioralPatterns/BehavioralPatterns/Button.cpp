#include "Button.h"

Button::Button(Widget *h, Topic t) : Widget(h, t) {}

void Button::HandleHelp()
{
	if (HasHelp())
	{
		//offer help on the button
	}
	else
		HelpHandler::HandleHelp();
}