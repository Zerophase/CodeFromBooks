#include "Point.h"

Point::Point(float x, float y)
{
	this->x = x;
	this->y = y;
}

Point::Point(Coord bottom, Coord left)
{
	this->x = left.GetX();
	this->y = bottom.GetX();
}

float Point::X() const
{
	/*Coord tempX = Coord(this->x, 0.0f);
	return tempX;*/
	return this->x;
}

float Point::Y() const
{
	//Coord tempY = Coord(0.0f, this->y);
	//return tempY;
	return this->y;
}

Point Point::Zero()
{
	return Point(0, 0);
}

bool operator==(const Point &checkedPoint, const Point &comparisonPoint)
{
	return (checkedPoint.x == comparisonPoint.x && checkedPoint.y == comparisonPoint.y);
}

ostream &operator<<(ostream &output, const Point &input)
{
	output << input;
	return output;
}

istream &operator>>(istream &input, const Point &output)
{
	input >> output;
	return input;
}