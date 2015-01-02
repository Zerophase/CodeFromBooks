#include "ListBox.h"
#include "MouseEvent.h"

ListBox::ListBox(DialogDirector *director) : WidgetMediator(director)
{

}

const char *ListBox::GetSelection()
{
	char temp = 'a';
	return &temp;
}

void ListBox::SetList(std::list<char*> listItems)
{

}

void ListBox::HandleMouse(MouseEvent &mouseEvent)
{

}