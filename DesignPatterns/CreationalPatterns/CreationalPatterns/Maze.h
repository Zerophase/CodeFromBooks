#ifndef MAZE_H
#define MAZE_H

#include "Room.h"
//Might not be ideal place to include Door
#include "Door.h"
class Maze 
{
	public:
		Maze();
		Maze(const Maze &otherMaze);

		void AddRoom(Room *roomToAdd);
		Room * RoomNum(int currentRoomNum) const;
		
		virtual void Initialize(Maze *maze);
		virtual Maze *Clone() const;

	private:
		Maze *maze;
		//
};
#endif // !MAZE_H
