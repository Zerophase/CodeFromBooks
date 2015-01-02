#ifndef POINT_H
#define POINT_H

#include "Coord.h"
#include <iostream>
using namespace std;

class Point
{
	public:
		Point(float x = 0.0f, float y = 0.0f);
		Point(Coord bottom, Coord left);
		static Point Zero();
		float X() const;
		float Y() const;

		friend bool operator==(const Point &checkedPoint, const Point &ComparisonPoint);
		friend ostream &operator<<(ostream &output, const Point &input);
		friend istream &operator>>(istream &input, const Point &output);
	private:
		float x;
		float y;
};
#endif // !POINT_H
