#ifndef ROOMWITHABOMB
#define ROOMWITHABOMB

#include "Room.h"

class RoomWithABomb : public Room
{
	public:
		RoomWithABomb();
		RoomWithABomb(const RoomWithABomb &otherRoomWithABomb);
		RoomWithABomb(int roomNum);

		virtual void Initialize(RoomWithABomb *roomWithABomb);
		virtual RoomWithABomb *Clone() const;

		virtual void Enter();

	private:
		RoomWithABomb *roomWithABomb;
};

#endif // !ROOMWITHABOMB
