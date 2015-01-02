#ifndef BUILDERMADEMAZE
#define BUILDERMADEMAZE

#include "StandardMazeBuilder.h"

#include "CountingMazeBuilder.h"
#include <iostream>

#include "MazeGame.h"

using namespace std;

class BuilderMadeMaze
{
	public:
		BuilderMadeMaze();
		void CountUpMaze();

	private:
		//TODO operator overloading so maze can be assigned to another maze object.
		Maze _maze;
		MazeGame _game;
};
#endif // !BUILDERMAZEBUILDER

