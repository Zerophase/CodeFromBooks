#include "MazePrototypeFactoryImplementation.h"
//TODO move this to a better place
#include "BombedWall.h"
#include "RoomWithABomb.h"

MazePrototypeFactoryImplementation::MazePrototypeFactoryImplementation()
{
	MazeGame game;
	MazePrototypeFactory simpleMazeFactory
	{
		new Maze, new Wall, new Room, new Door
	};

	//For creating a different type of maze
	MazePrototypeFactory bombedMazeFactory
	{
		new Maze, new BombedWall, 
		new RoomWithABomb, new Door
	};

	Maze *maze = game.CreateMaze(simpleMazeFactory);
}

