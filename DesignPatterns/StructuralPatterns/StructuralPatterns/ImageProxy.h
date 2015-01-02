#ifndef IMAGEPROXY_H
#define IMAGEPROXY_H

//#include "Graphic.h"
#include "Image.h"

class ImageProxy : public Graphic
{
public:
	ImageProxy(const char *imageFile);
	virtual ~ImageProxy();

	virtual void Draw(const Point &at);
	virtual void HandleMouse(Event &theEvent);

	virtual const Point &GetExtent();

	virtual void Load(istream &from);
	virtual void Save(ostream &to);
protected:
	Image *GetImage();
private:
	Image *image;
	Point theExtent;
	Point checkExtent;
	char *fileName;
};
#endif // !IMAGEPROXY_H
