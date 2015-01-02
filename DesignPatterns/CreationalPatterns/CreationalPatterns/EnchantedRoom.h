#ifndef ENCHANTEDROOM_H
#define ENCHANTEDROOM_H

#include "Room.h"

enum Spell { NULL };

class EnchantedRoom : public Room
{
	public:
		EnchantedRoom(int roomNum, Spell *spellToOpen);
};
#endif // !ENCHANTEDROOM_H
