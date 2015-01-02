#ifndef DOORNEEDINGSPELL_H
#define DOORNEEDINGSPELL_H

#include "Door.h"

class DoorNeedingSpell : public Door
{
	public:
		DoorNeedingSpell(Room *roomOne, Room *roomTwo);
};
#endif // !DOORNEEDINGSPELL_H
