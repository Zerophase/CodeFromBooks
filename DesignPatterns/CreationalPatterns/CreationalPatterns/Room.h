#ifndef ROOM_H
#define ROOM_H

#include "MapSite.h"
//Might not be the ideal place to include Wall
#include "Wall.h"

class Room : public MapSite
{
	public:
		Room();
		Room(const Room &otherRoom);
		Room(int roomNum);

		MapSite *GetSide(Direction direction) const;
		void SetSide(Direction direction, MapSite *mapSite);

		virtual void Initialize(Room *room);
		virtual Room *Clone() const;

		virtual void Enter();

	private:
		MapSite *sides[4];
		int roomNumber;

		Room *room;
};
#endif // !ROOM_H

