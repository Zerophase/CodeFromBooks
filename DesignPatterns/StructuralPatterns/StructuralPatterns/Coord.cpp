#include "Coord.h"

Coord::Coord(float x, float y)
{
	this->x = x;
	this->y = y;
}

float Coord::GetX()
{
	return this->x;
}

float Coord::GetY()
{
	return this->y;
}

void Coord::SetX(float x)
{
	this->x = x;
}

void Coord::SetY(float y)
{
	this->y = y;
}

Coord operator+(const Coord &c1, const Coord &c2)
{
	return Coord(c1.x + c2.x, c1.y + c2.y);
}