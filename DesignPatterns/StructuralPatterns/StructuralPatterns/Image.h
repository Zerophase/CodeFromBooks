#ifndef IMAGE_H
#define IMAGE_H

#include "Graphic.h"

class Image : public Graphic
{
public:
	Image(const char *file);
	virtual ~Image();

	virtual void Draw(const Point &at);
	virtual void HandleMouse(Event &theEvent);

	virtual const Point &GetExtent();

	virtual void Load(istream &from);
	virtual void Save(ostream &to);
private:
	const Point testPoint;
	//...
};

#endif // !IMAGE_H
