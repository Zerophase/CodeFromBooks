#include "BombedMazeGame.h"

BombedMazeGame::BombedMazeGame()
{

}

Wall *BombedMazeGame::MakeWall() const
{
	return new BombedWall;
}

Room *BombedMazeGame::MakeRoom(int roomNum) const
{
	return new RoomWithABomb(roomNum);
}