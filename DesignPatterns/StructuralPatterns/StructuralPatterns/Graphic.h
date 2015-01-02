#ifndef GRAPHIC_H
#define GRAPHIC_H

#include "Point.h"
#include <istream>

using namespace std;

class Event;

class Graphic
{
public:
	virtual ~Graphic();

	virtual void Draw(const Point &at) = 0;
	virtual void HandleMouse(Event &theEvent) = 0;

	virtual const Point &GetExtent() = 0;

	virtual void Load(istream &from) = 0;
	virtual void Save(ostream &to) = 0;
protected:
	Graphic();
private:
	Point testPoint;
};
#endif // !GRAPHIC_H
