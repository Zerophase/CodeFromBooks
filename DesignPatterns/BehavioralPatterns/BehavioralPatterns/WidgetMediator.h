#ifndef WIDGETMEDIATOR_H
#define WIDGETMEDIATOR_H

class DialogDirector;
class MouseEvent;

class WidgetMediator
{
public:
	WidgetMediator(DialogDirector*);
	virtual void Changed();

	virtual void HandleMouse(MouseEvent &mouseEvent);

private:
	DialogDirector *_director;
};
#endif // !WIDGETMEDIATOR_H
