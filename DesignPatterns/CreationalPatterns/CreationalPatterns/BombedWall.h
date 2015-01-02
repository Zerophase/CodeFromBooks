#ifndef BOMBEDWALL
#define BOMBEDWALL

#include "Wall.h"

class BombedWall : public Wall
{
	public:
		BombedWall();
		BombedWall(const BombedWall &bombedWall);

		virtual Wall *Clone() const;
		bool HasBomb();

		virtual void Enter();

	private:
		bool bomb;
};
#endif // !BOMBEDWALL
