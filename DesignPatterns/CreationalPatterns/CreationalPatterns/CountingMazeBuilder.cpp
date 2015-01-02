#include "CountingMazeBuilder.h"

CountingMazeBuilder::CountingMazeBuilder()
{
	this->rooms = this->doors = 0;
}

void CountingMazeBuilder::BuildMaze()
{

}

void CountingMazeBuilder::BuildRoom(int room)
{
	this->rooms++;
}

void CountingMazeBuilder::BuildDoor(int roomFrom, int roomTo)
{
	this->doors++;
}

void CountingMazeBuilder::AddWall(int roomNum, Direction sideForWall)
{

}

void CountingMazeBuilder::GetCounts(int &rooms, int &doors) const
{
	rooms = this->rooms;
	doors = this->doors;
}