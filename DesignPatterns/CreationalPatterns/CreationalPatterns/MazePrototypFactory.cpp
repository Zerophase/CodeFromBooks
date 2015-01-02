#include "MazePrototypeFactory.h"

MazePrototypeFactory::MazePrototypeFactory(Maze *maze, Wall *wall, Room *room, Door *door)
{
	prototypeMaze = maze;
	prototypeWall = wall;
	prototypeRoom = room;
	prototypeDoor = door;
}

Maze *MazePrototypeFactory::MakeMaze() const
{
	return prototypeMaze->Clone();
}

Room *MazePrototypeFactory::MakeRoom(int roomNum) const
{
	return prototypeRoom->Clone();
}

Wall *MazePrototypeFactory::MakeWall() const
{
	return prototypeWall->Clone();
}

Door *MazePrototypeFactory::MakeDoor(Room *roomOne, Room *roomTwo) const
{
	Door *door = prototypeDoor->Clone();
	door->Initialize(roomOne, roomTwo);
	return door;
}