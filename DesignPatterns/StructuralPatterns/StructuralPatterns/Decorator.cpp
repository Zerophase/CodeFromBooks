#include "Decorator.h"

Decorator::Decorator(VisualComponent *visualComponent)
{
	this->component = visualComponent;
}

void Decorator::Draw()
{
	component->Draw();
}

void Decorator::Resize()
{
	component->Resize();
}