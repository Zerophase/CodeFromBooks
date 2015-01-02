#ifndef LISTBOX_H
#define LISTBOX_H

#include "WidgetMediator.h"
#include <list>

class DialogDirector;
class MouseEvent;

class ListBox : public WidgetMediator
{
public:
	ListBox(DialogDirector*);

	virtual const char *GetSelection();
	virtual void SetList(std::list<char*> listItems);
	virtual void HandleMouse(MouseEvent &mouseEvent);
};
#endif // !LISTBOX_H
