#include "EnchantedMazeFactory.h"


EnchantedMazeFactory::EnchantedMazeFactory()
{

}

Room *EnchantedMazeFactory::MakeRoom(int roomNum) const
{
	return new EnchantedRoom(roomNum, CastSpell());
}

Door *EnchantedMazeFactory::MakeDoor(Room *roomOne, Room *roomTwo) const
{
	return new DoorNeedingSpell(roomOne, roomTwo);
}

Spell *EnchantedMazeFactory::CastSpell() const
{
	return new Spell;
}