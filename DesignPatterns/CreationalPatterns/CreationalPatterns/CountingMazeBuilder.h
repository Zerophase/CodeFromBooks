#ifndef COUNTINGMAZEBUILDER
#define COUNTINGMAZEBUILDER

#include "MazeBuilder.h"

class CountingMazeBuilder : public MazeBuilder
{
	public:
		CountingMazeBuilder();

		virtual void BuildMaze();
		virtual void BuildRoom(int room);
		virtual void BuildDoor(int roomFrom, int roomTo);
		virtual void AddWall(int roomNum, Direction sideForWall);

		//Counts components up
		void GetCounts(int &rooms, int &doors) const;

	private:
		int doors;
		int rooms;
};
#endif