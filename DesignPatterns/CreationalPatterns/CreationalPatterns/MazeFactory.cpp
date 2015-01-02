#include "MazeFactory.h"
//Abstract Factory
MazeFactory::MazeFactory()
{

}

Maze *MazeFactory::MakeMaze() const
{
	return new Maze;
}

Wall *MazeFactory::MakeWall() const
{
	return new Wall;
}

Room *MazeFactory::MakeRoom(int roomNum) const 
{
	return new Room(roomNum);
}

Door *MazeFactory::MakeDoor(Room *roomOne, Room *roomTwo) const
{
	//Restor for Factory Pattern
	return new Door(/*roomOne, roomTwo*/);
}

