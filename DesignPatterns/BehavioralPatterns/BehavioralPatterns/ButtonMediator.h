#ifndef BUTTONMEDIATOR_H
#define BUTTONMEDIATOR_H

#include "WidgetMediator.h"

class DialogDirector;
class MouseEvent;

class ButtonMediator : public WidgetMediator
{
public:
	ButtonMediator(DialogDirector*);

	virtual void SetText(const char *text);
	virtual void HandleMouse(MouseEvent &mouseEvent);
};

#endif // !BUTTONMEDIATOR_H
