#include "MazeGame.h"

//Abstract factory implementation
Maze *MazeGame::CreateMaze(MazeFactory &factory)
{
	Maze *aMaze = factory.MakeMaze();
	
	Room *roomOne = factory.MakeRoom(1);
	Room *roomTwo = factory.MakeRoom(2);

	Door *aDoor = factory.MakeDoor(roomOne, roomTwo);

	aMaze->AddRoom(roomOne);
	aMaze->AddRoom(roomTwo);

	roomOne->SetSide(North, factory.MakeWall());
	roomOne->SetSide(East, aDoor);
	roomOne->SetSide(South, factory.MakeWall());
	roomOne->SetSide(West, factory.MakeWall());

	roomTwo->SetSide(North, factory.MakeWall());
	roomTwo->SetSide(East, factory.MakeWall());
	roomTwo->SetSide(South, factory.MakeWall());
	roomTwo->SetSide(West, aDoor);

	return aMaze;
}
//
//Builder pattern implementation
//Maze *MazeGame::CreateMaze(MazeBuilder &builder)
//{
//	builder.BuildMaze();
//
//	builder.BuildRoom(1);
//	builder.BuildRoom(2);
//	builder.BuildDoor(1, 2);
//
//	return builder.GetMaze();
//}
//
//Maze *MazeGame::CreateComplexMaze(MazeBuilder &builder)
//{
//	builder.BuildRoom(1);
//	//...
//	builder.BuildRoom(1001);
//
//	return builder.GetMaze();
//}

//Factory Method Implementation
//Maze *MazeGame::CreateMaze()
//{
//	Maze *aMaze = MakeMaze();
//
//	Room *roomOne = MakeRoom(1);
//	Room *roomTwo = MakeRoom(2);
//	Door *theDoor = MakeDoor(roomOne, roomTwo);
//
//	aMaze->AddRoom(roomOne);
//	aMaze->AddRoom(roomTwo);
//
//	roomOne->SetSide(North, MakeWall());
//	roomOne->SetSide(East, theDoor);
//	roomOne->SetSide(South, MakeWall());
//	roomOne->SetSide(West, MakeWall());
//
//	roomTwo->SetSide(North, MakeWall());
//	roomTwo->SetSide(East, MakeWall());
//	roomTwo->SetSide(South, MakeWall());
//	roomTwo->SetSide(West, theDoor);
//
//	return aMaze;
//}
//
//Maze *MazeGame::MakeMaze() const
//{
//	return new Maze;
//}
//
//Room *MazeGame::MakeRoom(int roomNum) const
//{
//	return new Room(roomNum);
//}
//
//Wall *MazeGame::MakeWall() const
//{
//	return new Wall;
//}
//
//Door *MazeGame::MakeDoor(Room *roomOne, Room *roomTwo) const
//{
//	return new Door(roomOne, roomTwo);
//}