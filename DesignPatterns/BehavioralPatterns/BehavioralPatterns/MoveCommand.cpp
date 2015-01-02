#include "MoveCommand.h"
#include "ConstraintSolver.h"
#include "ConstraitSolverMemento.h"
#include "Graphic.h"

void MoveCommand::Execute()
{
	ConstraintSolver *solver = ConstraintSolver::Instance();
	_state = solver->CreateMemento(); // Create the momento
	_target->Move(_delta);
	solver->Solve();
}

void MoveCommand::Unexecute()
{
	ConstraintSolver *solver = ConstraintSolver::Instance();
	_target->Move(-_delta);
	solver->SetMemento(_state); // Restor solver state.
	solver->Solve();
}