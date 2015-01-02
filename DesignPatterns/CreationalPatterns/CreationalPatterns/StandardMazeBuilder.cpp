#include "StandardMazeBuilder.h"

StandardMazeBuilder::StandardMazeBuilder()
{
	currentMaze = 0;
}

void StandardMazeBuilder::BuildMaze()
{
	currentMaze = new Maze;
}

void StandardMazeBuilder::BuildRoom(int roomNum)
{
	if (!currentMaze->RoomNum(roomNum))
	{
		Room *room = new Room(roomNum);
		currentMaze->AddRoom(room);
		
		room->SetSide(North, new Wall);
		room->SetSide(South, new Wall);
		room->SetSide(East, new Wall);
		room->SetSide(West, new Wall);
	}
}

void StandardMazeBuilder::BuildDoor(int roomFrom, int roomTo)
{
	Room *roomOne = currentMaze->RoomNum(roomFrom);
	Room *roomTwo = currentMaze->RoomNum(roomTo);
	//For builder pattern
	/*Door *door = new Door(roomOne, roomTwo);

	roomOne->SetSide(commonWall(roomOne, roomTwo), door);
	roomTwo->SetSide(commonWall(roomTwo, roomOne), door);*/
}

Direction StandardMazeBuilder::commonWall(Room *roomOne, Room *roomTwo)
{
	//Probably buggy
	if (roomOne->GetSide(North) && roomTwo->GetSide(South))
		return South;
	else if (roomOne->GetSide(South) && roomTwo->GetSide(North))
		return North;
	else if (roomOne->GetSide(East) && roomTwo->GetSide(West))
		return West;
	else if (roomOne->GetSide(West) && roomTwo->GetSide(East))
		return East;
	else
		//TODO Make nullable
		//research how to make nullable in C++
		return Direction();
}
Maze *StandardMazeBuilder::GetMaze()
{
	return currentMaze;
}