#include "Maze.h"

Maze::Maze()
{

}

Maze::Maze(const Maze &otherMaze)
{
	this->maze = otherMaze.maze;
}

void Maze::AddRoom(Room *roomToAdd)
{

}

Room *Maze::RoomNum(int currentRoomNum) const
{
	return new Room(currentRoomNum);
}

void Maze::Initialize(Maze *maze)
{
	this->maze = maze;
}

Maze *Maze::Clone() const
{
	return new Maze(*this);
}