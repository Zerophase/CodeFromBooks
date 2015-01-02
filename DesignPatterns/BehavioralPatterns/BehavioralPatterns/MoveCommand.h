#ifndef MOVE_COMMAND_H
#define MOVE_COMMAND_H

#include "Point.h"

class Graphic;
class ConstraintSolverMemento;

class MoveCommand
{
public:
	MoveCommand(Graphic *Target, const Point &delta);
	void Execute();
	void Unexecute();

private:
	ConstraintSolverMemento *_state;
	Point _delta;
	Graphic *_target;
};
#endif // !MOVE_COMMAND_H
