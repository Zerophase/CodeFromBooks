#ifndef MAZEGAME_H
#define MAZEGAME_H

#include "MazeFactory.h"
#include "MazeBuilder.h"

class MazeGame
{
	public:
		//Abstract factory implentation
		Maze *CreateMaze(MazeFactory &factory);

		//Builder Pattern implementation
		//Maze *CreateMaze(MazeBuilder &builder);
		//Maze *CreateComplexMaze(MazeBuilder &builder);

		//Factory Pattern implementation
		//Maze *CreateMaze();

		//factory methods:

		//virtual Maze *MakeMaze() const;
		//virtual Room *MakeRoom(int roomNum) const;
		//virtual Wall *MakeWall() const;
		//virtual Door *MakeDoor(Room *roomOne, Room *roomTwo) const;
};
#endif 