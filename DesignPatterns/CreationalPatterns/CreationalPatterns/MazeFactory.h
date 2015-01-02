#ifndef MAZEFACTORY_H
#define MAZEFACTORY_H

#include "Maze.h"
#include "Wall.h"
#include "Room.h"
#include "Door.h"

class MazeFactory
{
	public:
		MazeFactory();

		virtual Maze *MakeMaze() const;
		virtual Wall *MakeWall() const;
		virtual Room *MakeRoom(int roomNum) const;
		virtual Door *MakeDoor(Room *roomOne, Room *roomTwo) const;
};
#endif