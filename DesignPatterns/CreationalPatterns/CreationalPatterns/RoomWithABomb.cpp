#include "RoomWithABomb.h"

RoomWithABomb::RoomWithABomb()
{

}

RoomWithABomb::RoomWithABomb(const RoomWithABomb &otherRoomWithABomb)
{
	this->roomWithABomb = otherRoomWithABomb.roomWithABomb;
}

RoomWithABomb::RoomWithABomb(int roomNum)
	:Room(roomNum)
{

}

void RoomWithABomb::Initialize(RoomWithABomb *roomWithABomb)
{
	this->roomWithABomb = roomWithABomb;
}

RoomWithABomb *RoomWithABomb::Clone() const
{
	return new RoomWithABomb(*this);
}

void RoomWithABomb::Enter()
{

}