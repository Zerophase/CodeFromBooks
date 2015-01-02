#include "ConstraintSolver.h"
#include "ConstraitSolverMemento.h"

ConstraintSolver *ConstraintSolver::Instance()
{
	static ConstraintSolver *instance;
	return instance;
}

ConstraintSolverMemento *ConstraintSolver::CreateMemento()
{
	return new ConstraintSolverMemento();
}

void ConstraintSolver::SetMemento(ConstraintSolverMemento *memento)
{

}

void ConstraintSolver::Solve()
{

}