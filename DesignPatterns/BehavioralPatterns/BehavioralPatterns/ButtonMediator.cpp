#include "ButtonMediator.h"
#include "MouseEvent.h"
#include "DialogDirector.h"

ButtonMediator::ButtonMediator(DialogDirector *dialogDirector)
: WidgetMediator(dialogDirector)
{
	
}

void ButtonMediator::SetText(const char *text)
{

}

void ButtonMediator::HandleMouse(MouseEvent &mouseEvent)
{
	Changed();
}