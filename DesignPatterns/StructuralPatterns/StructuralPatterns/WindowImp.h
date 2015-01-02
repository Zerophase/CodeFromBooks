#ifndef WINDOWIMP_H
#define WINDOWIMP_H

#include "Point.h"

class WindowImp
{
	public:
		virtual void ImpTop() = 0;
		virtual void ImpBotom() = 0;
		virtual void ImpSetExtent(const Point &extent) = 0;
		virtual void ImpGetOrigin(const Point &origin) = 0;

		virtual void DeviceRect(Coord left, Coord bottom, Coord right, Coord top) = 0;
		virtual void DeviceText(const char *text, Coord left, Coord top) = 0;
		virtual void DeviceBitmap(const char *bitmap, Coord left, Coord top) = 0;
		//lots more functions for drawing on windows
	
	protected:
		WindowImp();
};
#endif // !WINDOWIMP_H
