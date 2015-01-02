#ifndef ENTRYFIELD_H
#define ENTRYFIELD_H

#include "WidgetMediator.h"

class DialogDirector;
class MouseEvent;

class EntryField : public WidgetMediator
{
public:
	EntryField(DialogDirector*);

	virtual void SetText(const char *text);
	virtual const char *GetText();
	virtual void HandleMouse(MouseEvent &MouseEvent);

};
#endif // !ENTRYFIELD_H
