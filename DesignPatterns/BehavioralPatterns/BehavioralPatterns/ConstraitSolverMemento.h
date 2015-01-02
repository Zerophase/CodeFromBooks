#ifndef CONSTRAINT_SOLVER_MEMENTO_H
#define CONSTRAINT_SOLVER_MEMENTO_H

class ConstraintSolver;

class ConstraintSolverMemento
{
public:
	virtual ~ConstraintSolverMemento();

private:
	friend class ConstraintSolver;
	ConstraintSolverMemento();

	// Private ConstraintSolver state
};
#endif // !CONSTRAINT_SOLVER_H
