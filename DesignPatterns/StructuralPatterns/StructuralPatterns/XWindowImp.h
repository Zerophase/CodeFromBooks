#ifndef XWINDOWIMP_H
#define XWINDOWIMP_H

#include "WindowImp.h"
class Display;
class Drawable;
class GC;

class XWindowImp : public WindowImp
{
	public:
		XWindowImp();

		virtual void DeviceRect(Coord left, Coord bottom, Coord right, Coord top);
};
#endif // !XWINDOWIMP_H
