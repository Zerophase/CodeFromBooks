#ifndef STANDARDMAZEBUILDER_H
#define STANDARDMAZEBUILDER_H

#include "MazeBuilder.h"

class StandardMazeBuilder : public MazeBuilder
{
	public:
		StandardMazeBuilder();

		virtual void BuildMaze();
		virtual void BuildRoom(int roomNum);
		virtual void BuildDoor(int roomFrom, int roomTo);

		virtual Maze *GetMaze();

	private:
		Direction commonWall(Room *roomOne, Room *roomTwo);
		Maze *currentMaze;
};
#endif // !STANDARDMAZEBUILDER_H
