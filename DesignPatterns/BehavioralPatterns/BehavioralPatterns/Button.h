#ifndef BUTTON_H
#define BUTTON_H

#include "Widget.h"

class Button : public Widget
{
public:
	Button(Widget *d, Topic t = NO_HELP_TOPIC);

	virtual void HandleHelp();
};
#endif // !BUTTON_H
