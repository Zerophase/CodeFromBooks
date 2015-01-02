#ifndef ENCHANTEDMAZEFACTORY_H
#define ENCHANTEDMAZEFACTORY_H

#include "MazeFactory.h"
#include "DoorNeedingSpell.h"
#include "EnchantedRoom.h"


class EnchantedMazeFactory : public MazeFactory
{
	public:
		EnchantedMazeFactory();
		
		virtual Room *MakeRoom(int roomNum) const;
		virtual Door *MakeDoor(Room *roomOne, Room *roomTwo) const;

	protected:
		Spell *CastSpell() const;
};

#endif // !ENCHANTEDMAZEFACTORY_H
