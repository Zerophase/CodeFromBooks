#include "WidgetMediator.h"
#include "MouseEvent.h"
#include "DialogDirector.h"

WidgetMediator::WidgetMediator(DialogDirector* dialogDirector)
{
	_director = dialogDirector;
}

void WidgetMediator::Changed()
{
	_director->WidgetChanged(this);
}

void WidgetMediator::HandleMouse(MouseEvent &mouseEvent)
{

}