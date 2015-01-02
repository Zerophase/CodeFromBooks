#ifndef FLOPPYDISK_H
#define FLOPPYDISK_H

#include "Equipment.h"

class FloppyDisk : public Equipment
{
	public:
		FloppyDisk(const char *name);
		virtual ~FloppyDisk();

		virtual Watt Power();
		virtual Currency NetPrice();
		virtual Currency DiscountPrice();
};
#endif // !FLOPPYDISK_H
