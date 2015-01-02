#ifndef WALL_H
#define WALL_H
#include "MapSite.h"

class Wall : public MapSite
{
	public:
		Wall();
		Wall(const Wall &otherWall);

		virtual void Initialize(Wall *wall);
		virtual Wall *Clone() const;

		virtual void Enter();

	private:
		Wall *wall;
};
#endif // !WALL_H
