#ifndef BORDERDECORATOR_H
#define BORDERDECORATOR_H

#include "Decorator.h"

class BorderDecorator : public Decorator
{
	BorderDecorator(VisualComponent *visualComponent, int borderWidth);

	virtual void Draw();
private:
	void DrawBorder(int borderWidth);
	int width;
};
#endif // !BORDERDECORATOR_H
