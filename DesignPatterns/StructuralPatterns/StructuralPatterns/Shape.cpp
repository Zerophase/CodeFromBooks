#include "Shape.h"

Shape::Shape()
{

}

void Shape::BoundingBox(
	Point &bottomLeft, Point &topRight) const
{

}

Manipulator *Shape::CreateManipulator() const
{
	return new Manipulator;
}