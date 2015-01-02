#include "BombedWall.h"

BombedWall::BombedWall()
{

}

BombedWall::BombedWall(const BombedWall &otherBombedWall)
	: Wall(otherBombedWall)
{
	this->bomb = otherBombedWall.bomb;
}

Wall *BombedWall::Clone() const
{
	return new BombedWall(*this);
}

bool BombedWall::HasBomb()
{
	if (this->bomb)
		return true;
	else
		return false;
}

void BombedWall::Enter()
{

}