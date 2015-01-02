#include "Graphic.h"
#include "Point.h"

void Graphic::Move(Point p)
{

}

Point operator-(Point &p)
{
	p.x *= -1;
	p.y *= -1;
	return p;
}