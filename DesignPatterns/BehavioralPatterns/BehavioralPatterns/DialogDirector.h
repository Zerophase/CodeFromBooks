#ifndef DIALOGDIRECTOR_H
#define DIALOGDIRECTOR_H

class WidgetMediator;

//Mediator
class DialogDirector
{
public:
	virtual ~DialogDirector();

	virtual void ShowDialog();
	virtual void WidgetChanged(WidgetMediator*) = 0;

protected:
	DialogDirector();
	virtual void CreateWidgets() = 0;
};
#endif // !DIALOGDIRECTOR_H
