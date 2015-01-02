#include "DialogDirector.h"
#include "MouseEvent.h"
#include "EntryField.h"

EntryField::EntryField(DialogDirector *director) : WidgetMediator(director)
{

}

void EntryField::SetText(const char *text)
{

}

const char *EntryField::GetText()
{
	char temp = 'a';
	return &temp;
}

void EntryField::HandleMouse(MouseEvent &mouseEvent)
{

}