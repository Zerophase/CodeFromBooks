#ifndef ENCHANTEDMAZEGAME
#define ENCHANTEDMAZEGAME

#include "MazeGame.h"
#include "DoorNeedingSpell.h"
#include "EnchantedRoom.h"

class EnchantedMazeGame : public MazeGame
{
	public:
		EnchantedMazeGame();

		
		virtual Room *MakeRoom(int roomNum) const;

		virtual Door *MakeDoor(Room *roomOne, Room *roomTwo) const;

	protected:
		Spell *CastSpell() const;
};
#endif // !ENCHANTEDMAZEGAME
