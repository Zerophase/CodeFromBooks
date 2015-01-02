#include "BorderDecorator.h"

BorderDecorator::BorderDecorator(VisualComponent *visualComponent, int borderWidth)
: Decorator(visualComponent)
{
	this->width = borderWidth;
}

void BorderDecorator::Draw()
{
	Decorator::Draw();
	DrawBorder(width);
}

void BorderDecorator::DrawBorder(int borderWidth)
{

}