#include "Wall.h"

Wall::Wall()
{

}

Wall::Wall(const Wall &otherWall)
{
	this->wall = otherWall.wall;
}

void Wall::Initialize(Wall *wall)
{
	this->wall = wall;
}

Wall *Wall::Clone() const
{
	return new Wall(*this);
}

void Wall::Enter()
{

}