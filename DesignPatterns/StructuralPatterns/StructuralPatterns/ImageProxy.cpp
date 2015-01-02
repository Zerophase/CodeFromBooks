#include "ImageProxy.h"

ImageProxy::ImageProxy(const char *fileName)
{
	this->fileName = _strdup(fileName);
	theExtent = Point::Zero();
	image = 0;
}

ImageProxy::~ImageProxy()
{

}

Image *ImageProxy::GetImage()
{
	if (image == 0)
		image = new Image(this->fileName);
	return image;
}

void ImageProxy::Draw(const Point &at)
{
	GetImage()->Draw(at);
}

void ImageProxy::HandleMouse(Event &theEvent)
{
	GetImage()->HandleMouse(theEvent);
}

const Point &ImageProxy::GetExtent()
{
	if (theExtent == checkExtent)
		return theExtent;
}

void ImageProxy::Load(istream &from)
{
	from >> theExtent >> fileName;
}

void ImageProxy::Save(ostream &to)
{
	to << theExtent << fileName;
}