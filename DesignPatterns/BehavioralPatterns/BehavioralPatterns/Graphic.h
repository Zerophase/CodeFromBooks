#ifndef GRAPHIC_H
#define GRAPHIC_H

class Point;

class Graphic
{
public:
	void Move(Point);

	friend Point operator-(Point &p);
};
#endif // !GRAPHIC_H
