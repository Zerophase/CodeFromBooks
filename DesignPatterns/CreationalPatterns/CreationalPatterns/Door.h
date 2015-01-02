#ifndef DOOR_H
#define DOOR_H

#include "MapSite.h"
#include "Room.h"

class Door : public MapSite
{
	public:
		Door();
		Door(const Door &otherDoor);
		
		//For Abstract Factory pattern
		//Door(Room *roomOne = 0, Room *roomTwo = 0);

		virtual void Initialize(Room *roomOne, Room *roomTwo);
		virtual Door *Clone() const;

		virtual void Enter();
		Room *OtherSideFrom(Room *otherRoom);

	private:
		Room *roomOne;
		Room *roomTwo;
		//bool isOpen;
};
#endif // !DOOR_H
