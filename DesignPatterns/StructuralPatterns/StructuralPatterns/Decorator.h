#ifndef DECORATOR_H
#define DECORATOR_H

#include"VisualComponent.h"

class Decorator : public VisualComponent
{
public:
	Decorator(VisualComponent *visualComponent);

	virtual void Draw();
	virtual void Resize();

private:
	VisualComponent *component;
};
#endif // !DECORATOR_H
