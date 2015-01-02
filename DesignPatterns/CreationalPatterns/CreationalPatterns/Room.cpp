#include "Room.h"

Room::Room()
{

}

Room::Room(const Room &otherRoom)
{
	this->room = otherRoom.room;
}

Room::Room(int roomNum)
{

}

MapSite *Room::GetSide(Direction direction) const
{
	return sides[direction];
}

void Room::SetSide(Direction direction, MapSite *mapSite)
{

}

void Room::Initialize(Room *room)
{
	this->room = room;
}

Room *Room::Clone() const
{
	return new Room(*this);
}

void Room::Enter()
{

}