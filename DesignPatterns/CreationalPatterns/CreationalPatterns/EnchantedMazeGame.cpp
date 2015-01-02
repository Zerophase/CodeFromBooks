#include "EnchantedMazeGame.h"

EnchantedMazeGame::EnchantedMazeGame()
{

}

Room *EnchantedMazeGame::MakeRoom(int roomNum) const
{
	return new EnchantedRoom(roomNum, CastSpell());
}

Door *EnchantedMazeGame::MakeDoor(Room *roomOne, Room *roomTwo) const
{
	return new DoorNeedingSpell(roomOne, roomTwo);
}

Spell *EnchantedMazeGame::CastSpell() const
{
	return new Spell;
}