#ifndef MAZEPROTOTYPEFACTORY_H
#define MAZEPROTOTYPEFACTORY_H

#include "MazeFactory.h"

class MazePrototypeFactory : public MazeFactory
{
	public:
		MazePrototypeFactory(Maze *maze, Wall *wall, Room *room, Door *door);

		virtual Maze *MakeMaze() const;
		virtual Room *MakeRoom(int roomNum) const;
		virtual Wall *MakeWall() const;
		virtual Door *MakeDoor(Room *roomOne, Room *roomTwo) const;

	private:
		Maze *prototypeMaze;
		Room *prototypeRoom;
		Wall *prototypeWall;
		Door *prototypeDoor;
};
#endif // !MAZEPROTOTYPEFACTORY
