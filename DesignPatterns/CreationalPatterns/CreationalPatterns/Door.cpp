#include "Door.h"

Door::Door()
{

}

Door::Door(const Door &otherDoor)
{
	this->roomOne = otherDoor.roomOne;
	this->roomTwo = otherDoor.roomTwo;
}

void Door::Initialize(Room *roomOne, Room *roomTwo)
{
	this->roomOne = roomOne;
	this->roomTwo = roomTwo;
}

Door *Door::Clone() const
{
	return new Door(*this);
}
//Door::Door(Room *roomOne, Room *roomTwo)
//{
//
//}

void Door::Enter()
{

}

Room *Door::OtherSideFrom(Room *otherRoom)
{
	return roomOne;
}