#ifndef BOMBEDMAZEGAME
#define BOMBEDMAZEGAME

#include "MazeGame.h"
#include "BombedWall.h"
#include "RoomWithABomb.h"

class BombedMazeGame : public MazeGame
{
	public:
		BombedMazeGame();

		virtual Wall *MakeWall() const;
		virtual Room *MakeRoom(int roomNum) const;
};
#endif // !BOMBEDMAZEGAME
